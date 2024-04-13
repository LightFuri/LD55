using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMobModel : MonoBehaviour
{
    public ObjectsEnum MobType { get; set; }
    public Point Position { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int AttackRange { get; set; }
    public int CastPrice { get; set; }
    public bool IsEnemy { get; set; }
    public void MoveToClosestEnemy(BaseMobModel? enemy)
    {
        if (enemy != null)
        {
            Point currentPosition = this.Position;
            Point enemyPosition = enemy.Position;

            int deltaX = enemyPosition.X - currentPosition.X;
            int deltaY = enemyPosition.Y - currentPosition.Y;

            int stepX = Math.Sign(deltaX);
            int stepY = Math.Sign(deltaY);

            int newX = currentPosition.X + stepX;
            int newY = currentPosition.Y + stepY;

            if (newX >= 0 && newX < MapModel.Map.GetLength(0) && newY >= 0 && newY < MapModel.Map.GetLength(1))
            {
                if (MapModel.Map[newX, newY] == ObjectsEnum.Empty)
                {
                    MapModel.Map[currentPosition.X, currentPosition.Y] = ObjectsEnum.Empty;

                    currentPosition.X = newX;
                    currentPosition.Y = newY;
                    this.Position = currentPosition;

                    MapModel.Map[currentPosition.X, currentPosition.Y] = this.MobType;
                }
            }
        }
    }
    public BaseMobModel? FindClosestEnemy()
    {
        Point currentPosition = this.Position;
        BaseMobModel? closestEnemy = null;
        double closestDistance = double.MaxValue;

        BaseMobModel[] mobs = FindObjectsOfType<BaseMobModel>();

        foreach (var mob in mobs)
        {
            if (mob.IsEnemy != this.IsEnemy)
            {
                int dx = currentPosition.X - mob.Position.X;
                int dy = currentPosition.Y - mob.Position.Y;
                double distance = Math.Sqrt(dx * dx + dy * dy);

                if (distance < closestDistance)
                {
                    closestEnemy = mob;
                    closestDistance = distance;
                }
            }
        }

        return closestEnemy;
    }

    public bool IsEnemyInRange(BaseMobModel? enemy)
    {
        if (enemy == null)
        {
            return false;
        }

        Point currentPosition = this.Position;
        int dx = currentPosition.X - enemy.Position.X;
        int dy = currentPosition.Y - enemy.Position.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);

        return distance <= this.AttackRange;
    }

    public void Attack(BaseMobModel? enemy)
    {
        if (enemy != null)
        {
            enemy.Health -= this.Damage;
            if (enemy.Health <= 0)
            {
                MobSpawner.Remove(enemy);
            }
        }
    }

    public void UseSkill()
    {

    }
}
