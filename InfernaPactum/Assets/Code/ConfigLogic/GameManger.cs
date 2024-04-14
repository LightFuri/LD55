using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private string _nameMusic;

    private SoundController _soundHandler;

    public void Awake()
    {
        _soundHandler = FindObjectOfType<SoundController>();
        _soundHandler.PlaySound(_nameMusic);
    }
}
