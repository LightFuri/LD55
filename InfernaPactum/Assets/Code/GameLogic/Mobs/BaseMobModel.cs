using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMobModel : MonoBehaviour
{
    public ObjectsEnum MobType { get; set; }
    public Point Position { get; set; }
    public int Health { get; set; }
    public int MaxHealth { get; set; }
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

    private IEnumerator SmoothMove(Vector3 start, Vector3 end, float duration)
    {
        float elapsed = 0;
        while (elapsed < duration)
        {
            this.transform.localPosition = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        this.transform.localPosition = end; 
    }

    private void Move(Point currentPosition, int newX, int newY)
    {
        float duration = 0.5f;
        MapModel.Map[currentPosition.X, currentPosition.Y] = ObjectsEnum.Empty;

        Vector3 startPos = new Vector3(currentPosition.X, currentPosition.Y, 1);

        Vector3 endPos = new Vector3(newX, newY, 1);

        StartCoroutine(SmoothMove(startPos, endPos, duration));

        currentPosition.X = newX;
        currentPosition.Y = newY;
        this.Position = currentPosition;
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

            UpdateHealthBar(enemy);

            if(enemy.Health <= 0)
            {
                MapModel.Map[enemy.Position.X, enemy.Position.Y] = ObjectsEnum.Empty;
                Destroy(enemy.gameObject);
            }
        }
            
    }
    void UpdateHealthBar(BaseMobModel enemy)
    {
        var healthBar = enemy.transform.Find("HealthBar");
        var originalSize = healthBar.GetComponent<SpriteRenderer>().size.x;
        float healthPercent = (float)enemy.Health / enemy.MaxHealth;
        healthBar.localScale = new Vector3(healthPercent, healthBar.localScale.y, healthBar.localScale.z); 

        healthBar.localPosition = new Vector3((healthPercent - 1) * originalSize / 2, healthBar.localPosition.y, healthBar.localPosition.z);
    }
    public void UseSkill()
    {

    }
}
