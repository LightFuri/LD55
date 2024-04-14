using UnityEngine;

public class BootStraper : MonoBehaviour
{
    private LoadLevel _loadLevel;
    private SoundController _soundHandler;

    private void Awake()
    {
        var canvas = Creat(ConstProvider.PATH_BOOTSTRAPPER_CANVAS);
        _loadLevel = canvas.GetComponent<LoadLevel>();

        var soundHandler = Creat(ConstProvider.PATH_BOOTSTRAPPER_AUDIOSOURS);
        _soundHandler = soundHandler.GetComponent<SoundController>();


        _loadLevel.Init(ConstProvider.LOBBY_ID);
        _soundHandler.Init(ConstProvider.STANDAED_VOLUME_AUDIO, ConstProvider.STANDAED_VOLUME_MUSIC);
        DontDestroyOnLoad(this);
    }

    public GameObject Creat(string path)
    {
        var prefab = Resources.Load<GameObject>(path);
        var product = Instantiate(prefab, transform);
        return product;
    }
}
