using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private LoadLeaval _loadLeaval;

    private void Awake()
    {
        var prefab = Resources.Load<GameObject>(ConstProvider.PATH_BOOTSTRAPPER);
        var canvas =  Instantiate(prefab);
        _loadLeaval = canvas.GetComponent<LoadLeaval>();
        _loadLeaval.Init(ConstProvider.LobbiLeavlID);

        DontDestroyOnLoad(this);
    }
}
