using Backend.Utils;

namespace Backend.Object.UI
{
    public class EffectAudioSourceVolumeSlider : AudioSourceVolumeSlider
    {
        protected override void Awake()
        {
            base.Awake();
            
            var volume = DataManager.UserData.EffectAudioSourceVolume;
            
            Slider.value = volume;
            
            SoundManager.SetEffectAudioSourceVolume(volume);
        }

        protected override void SetVolume(float volume)
        {
            SoundManager.SetEffectAudioSourceVolume(volume);
            
            DataManager.UserData.EffectAudioSourceVolume = volume;
            DataManager.Save();
        }
    }
}