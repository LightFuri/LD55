using Code.GameLogic.Sound;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
     private AudioSource _audioSource;
     private SoundSlider _soundSlider;
    private AudioClip _audioClip;

    private void Start()
    {
       

        _audioSource = GetComponent<AudioSource>();

        _soundSlider = FindObjectOfType<SoundSlider>();
        _soundSlider.CnangeValueCallBack += ApplySound;
    }

    private void OnDisable()
    {
        _soundSlider.CnangeValueCallBack -= ApplySound;
    }

    public void ApplySound(float volume)
    {
        _audioSource.volume = volume;
    }   
}
