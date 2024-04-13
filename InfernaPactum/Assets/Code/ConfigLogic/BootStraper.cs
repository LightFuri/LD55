using UnityEngine;

public class BootStraper : MonoBehaviour
{
     private LoadLevel _loadLevel;

    private void Awake()
    {
        var prefab = Resources.Load<GameObject>(ConstProvider.PATH_BOOTSTRAPPER);
        var canvas =  Instantiate(prefab);
        _loadLevel = canvas.GetComponent<LoadLevel>();
        _loadLevel.Init(ConstProvider.LobbiLeavlID);

        DontDestroyOnLoad(this);
    }
}
