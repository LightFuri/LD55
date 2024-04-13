using UnityEngine;

public class BootStraper : MonoBehaviour
{
    [SerializeField] private LoadLevel _loadLevel;
    int i = 0;

    private void Awake()
    {
        i++;
        var prefab = Resources.Load<GameObject>(ConstProvider.PATH_BOOTSTRAPPER);
        var canvas =  Instantiate(prefab, transform);
        _loadLevel = canvas.GetComponent<LoadLevel>();


        _loadLevel.Init(ConstProvider.LobbiLeavlID);
        Debug.Log(i);
        DontDestroyOnLoad(this);
    }
}
