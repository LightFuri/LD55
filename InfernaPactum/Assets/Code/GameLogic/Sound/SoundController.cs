using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private float _volumeMusic;
    private float _volumeAudio;
    private AudioSource _musicSource;
    private AudioSource _audioSource;
    private readonly Dictionary<string, AudioClip> _sounds = new();

    public void Init(float volumeMusic, float volumeAudio)
    {
        _volumeMusic = volumeMusic;
        _volumeAudio = volumeAudio;
        _musicSource = transform.GetChild(0).GetComponent<AudioSource>();
        _audioSource = transform.GetChild(1).GetComponent<AudioSource>();
        AddVolumeMusic(_volumeMusic);
        AddVolumeAudio(_volumeAudio);
        AddClips();
    }

    public void PlaySound(string name)
    {
        _musicSource.clip = FindSound(name);
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void PlayOne(string name)
    {
        var clip = FindSound(name);      
        _audioSource.PlayOneShot(clip);     
    }

    public void AddVolumeMusic(float volume)
    {
        _volumeMusic = volume;
        _musicSource.volume = volume;
    }

    public void AddVolumeAudio(float volume)
    {
        _volumeAudio = volume;
        _audioSource.volume = volume;
    }


    public void OffSound()
    {
        _musicSource.Stop();
        _audioSource.Stop();   
    }

    private AudioClip FindSound(string name) 
    {
        _sounds.TryGetValue(name, out AudioClip clip);
        return clip;
    }
    private void AddClips()
    {
        AudioClip[] clips = Resources.LoadAll<AudioClip>(ConstProvider.PATH_RESOURCES_SOUND); 

        foreach (AudioClip clip in clips)
        {
            _sounds.Add(clip.name, clip);
        }
    }


    

    
   
}
