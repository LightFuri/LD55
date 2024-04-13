using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHandler : MonoBehaviour
{
    public ObjectsEnum MobType;
    public void ChangeState()
    {
        SpawnState.MobType = MobType;
        SpawnState.SpawnEnabled = !SpawnState.SpawnEnabled;
    }
}
