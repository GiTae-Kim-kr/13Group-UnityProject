using Backend.Utils;

namespace Backend.Object.UI
{
    public class BackgroundAudioSourceVolumeSlider : AudioSourceVolumeSlider
    {
        protected override void Awake()
        {
            base.Awake();
            
            var volume = DataManager.UserData.BackgroundAudioSourceVolume;
            
            Slider.value = volume;
            
            SoundManager.SetBackgroundAudioSourceVolume(volume);
        }

        protected override void SetVolume(float volume)
        {
            SoundManager.SetBackgroundAudioSourceVolume(volume);
            
            DataManager.UserData.BackgroundAudioSourceVolume = volume;
            DataManager.Save();
        }
    }
}