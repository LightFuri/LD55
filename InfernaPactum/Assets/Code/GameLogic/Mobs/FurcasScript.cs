using UnityEngine;

public class FurcasScript : BaseMobModel
{
    private void Start()
    {
        InvokeRepeating("RepeatedUpdate", 0f, 1f);
    }

    private void RepeatedUpdate()
    {
        if (base.Health > 0)
        {
            var closestEnemy = FindClosestEnemy();
            var isEnemyInAttackRange = IsEnemyInRange(closestEnemy);
            if (isEnemyInAttackRange)
            {
                Attack(closestEnemy);
            }
            else
            {
                MoveToClosestEnemy(closestEnemy);
            }
        }
        else
        {
            MapModel.Map[Position.X, Position.Y] = ObjectsEnum.Empty;
            Destroy(gameObject);
        }
    }
}