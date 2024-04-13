using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private LoadLevell _loadLeaval;

    private void Awake()
    {
        var prefab = Resources.Load<GameObject>(ConstProvider.PATH_BOOTSTRAPPER);
        var canvas =  Instantiate(prefab);
        _loadLeaval = canvas.GetComponent<LoadLevell>();
        _loadLeaval.Init(ConstProvider.LobbiLeavlID);

        DontDestroyOnLoad(this);
    }
}
