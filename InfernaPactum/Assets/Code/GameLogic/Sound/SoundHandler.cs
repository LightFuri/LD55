using UnityEngine;
using UnityEngine.UI;

namespace Code.GameLogic.Sound
{
    public class SoundHandler : MonoBehaviour
    {
        [SerializeField] private Slider BGM;
        [SerializeField] private Slider SFX;

        private SoundController _soundController;

        private void Start()
        {
            _soundController = FindObjectOfType<SoundController>();
            BGM.value = ConstProvider.STANDAED_VOLUME_AUDIO;
            SFX.value = ConstProvider.STANDAED_VOLUME_MUSIC;
            BGM.onValueChanged.AddListener(ChangeMusic);
            SFX.onValueChanged.AddListener(ChangeAudio);
            
        }

        private void ChangeMusic(float volume)
        {
            _soundController.AddVolumeMusic(volume);
        }

        private void ChangeAudio(float volume)
        {
            _soundController.AddVolumeAudio(volume);
        }

    }
}