using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpawnState
{
    public static ObjectsEnum? MobType;
    public static bool SpawnEnabled = false;
    public static int Health { get; set; }
    public static  int MaxHealth { get; set; }
    public static int Damage { get; set; }
    public static int AttackRange { get; set; }
    public static int CastPrice { get; set; }
    public static bool IsEnemy { get; set; }
}
