using UnityEngine;

public class BootStraper : MonoBehaviour
{
    private LoadLevel _loadLevel;
    private SoundHandler _soundHandler;

    private void Awake()
    {
        var canvas = Creat(ConstProvider.PATH_BOOTSTRAPPER_CANVAS);
        _loadLevel = canvas.GetComponent<LoadLevel>();

        var soundHandler = Creat(ConstProvider.PaTH_BOOTSTRAPPER_AUDIOSOURS);
        _soundHandler = soundHandler.GetComponent<SoundHandler>();


        _loadLevel.Init(ConstProvider.LobbyID);
        _soundHandler.Init\\\\(ConstProvider.STANDAED_VOLUME_SOUND);
        DontDestroyOnLoad(this);
    }

    public GameObject Creat(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        var product = Instantiate(prefab, transform);
        return product;
    }
}
