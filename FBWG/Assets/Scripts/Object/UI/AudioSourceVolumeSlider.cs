using UnityEngine;
using UnityEngine.UI;

namespace Backend.Object.UI
{
    public abstract class AudioSourceVolumeSlider : MonoBehaviour
    {
        protected Slider Slider;
        
        protected virtual void Awake()
        {
            Slider = GetComponent<Slider>();
            Slider.onValueChanged.AddListener(SetVolume);
        }

        protected abstract void SetVolume(float volume);
    }
}