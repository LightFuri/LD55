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

    public void MoveToClosestEnemy(BaseMobModel enemy)
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

            if (CanMoveTo(newX, newY))
            {
                Move(currentPosition, newX, newY);
            }
            else
            {
                if (CanMoveTo(currentPosition.X + stepX, currentPosition.Y))
                {
                    Move(currentPosition, currentPosition.X + stepX, currentPosition.Y);
                }
                else if (CanMoveTo(currentPosition.X, currentPosition.Y + stepY))
                {
                    Move(currentPosition, currentPosition.X, currentPosition.Y + stepY);
                }
            }
        }
    }

    private bool CanMoveTo(int x, int y)
    {
        return x >= 0 && x < MapModel.Map.GetLength(0) && y >= 0 && y < MapModel.Map.GetLength(1) && MapModel.Map[x, y] == ObjectsEnum.Empty;
    }

    private void Move(Point currentPosition, int newX, int newY)
    {
        MapModel.Map[currentPosition.X, currentPosition.Y] = ObjectsEnum.Empty;
        currentPosition.X = newX;
        currentPosition.Y = newY;
        this.Position = currentPosition;
        this.transform.localPosition = new Vector3(Position.X, Position.Y, 1);
        MapModel.Map[newX, newY] = this.MobType;
    }
    public BaseMobModel FindClosestEnemy()
    {
        Point currentPosition = this.Position;
        BaseMobModel closestEnemy = null;
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

    public bool IsEnemyInRange(BaseMobModel enemy)
    {
        if (enemy == null)
        {
            return false;
        }

        Point currentPosition = this.Position;
        int dx = currentPosition.X - enemy.Position.X;
        int dy = currentPosition.Y - enemy.Position.Y;
        double distance = Math.Sqrt(dx * dx + dy * dy);
        int roundedDistance = (int)Math.Round(distance);

        return roundedDistance <= this.AttackRange;
    }

    public void Attack(BaseMobModel enemy)
    {
        if (enemy != null)
        {
            enemy.Health -= this.Damage;
        }
    }

    public void UseSkill()
    {

    }
}
