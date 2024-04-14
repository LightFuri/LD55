using UnityEngine;

public class GameManger : MonoBehaviour
{
    [SerializeField] private SoundController _soundHandler;

    public void Awake()
    {
        _soundHandler = FindObjectOfType<SoundController>();
        _soundHandler.PlaySound("MainMenu_Rhythm_70bpm_4-4_L28_P2M");
    }
}
