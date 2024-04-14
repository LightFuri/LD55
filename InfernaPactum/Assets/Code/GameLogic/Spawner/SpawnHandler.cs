using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHandler : MonoBehaviour
{
    public ObjectsEnum MobType;
    public int Health;
    public int MaxHealth;
    public int Damage;
    public int AttackRange;
    public int CastPrice;
    public bool IsEnemy;

    public void ChangeState()
    {
        SpawnState.MobType = MobType;
        SpawnState.Health = Health;
        SpawnState.MaxHealth = MaxHealth;
        SpawnState.Damage = Damage;
        SpawnState.AttackRange = AttackRange;
        SpawnState.CastPrice = CastPrice;
        SpawnState.IsEnemy = IsEnemy;
        SpawnState.SpawnEnabled = !SpawnState.SpawnEnabled;
    }
}
