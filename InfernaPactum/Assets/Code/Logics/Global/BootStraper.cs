using UnityEngine;

public class BootStraper : MonoBehaviour
{
     private LoadLeaval _loadLeaval;

    private void Awake()
    {
        var prefab = Resources.Load(ConstProvider);
        var canvas =  Instantiate(prefab);
        _loadLeaval = canvas.GetComponent<LoadLeaval>();
        _loadLeaval.Init(ConstProvider.LobbiLeavlID);

        DontDestroyOnLoad(this);
    }
}
