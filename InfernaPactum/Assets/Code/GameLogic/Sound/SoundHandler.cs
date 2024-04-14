using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundHandler : MonoBehaviour
{
    private float _volume;
    private AudioSource _audioSource;
    private readonly Dictionary<string, AudioClip> _sounds = new();

    public void Init(float volume)
    {
        _volume = volume;
        _audioSource = GetComponent<AudioSource>();
        AddClips();
        AddVolumeSound(_volume);
    }

    public void PlaySound(string name)
    {
        _audioSource.clip = FindSound(name);   
    }

    public void PlayOne(string name)
    {
        var clip = FindSound(name);
        _audioSource.PlayOneShot(clip);
    }

    public void AddVolumeSound(float volume)
    {
        _volume = volume;
        _audioSource.volume = volume;
    }

    public void OffSound()=> _audioSource.Stop();

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
