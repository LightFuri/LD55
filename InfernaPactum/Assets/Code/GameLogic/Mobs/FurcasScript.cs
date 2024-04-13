using UnityEngine;

public class FurcasScript : BaseMobModel
{
    [SerializeField] private HealthView healthView;

    private void Start()
    {
        healthView = GetComponent<HealthView>();
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
                Attack(closestEnemy, healthView);
               
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