using Backend.Data;
using UnityEngine;
using UnityEngine.Audio;

namespace Backend.Utils
{
    public class SoundManager : SingletonGameObject<SoundManager>
    {
        #region SERIALIZABLE FIELD API

        [Header("Master Audio Mixer")]
        [SerializeField] private AudioMixer master;

        [Header("Audio Mixer Group Settings")]
        [SerializeField] private AudioMixerGroup background;
        [SerializeField] private AudioMixerGroup effect;

        [Header("Data Settings")]
        [SerializeField] private AudioClipData backgroundAudioClipData;
        [SerializeField] private AudioClipData effectAudioClipData;
        
        #endregion

        private AudioSource _background;
        private AudioSource _effect;

        protected override void OnAwake()
        {
            base.OnAwake();

            _background = transform.GetChild(0).GetComponent<AudioSource>();
            _effect = transform.GetChild(1).GetComponent<AudioSource>();
        }

        private void PlayBackgroundAudioSource_Internal(int index)
        {
            _background.clip = backgroundAudioClipData[index];
            _background.Play();
        }

        private void StopBackgroundAudioSource_Internal()
        {
            if (_background.isPlaying == false)
            {
                return;
            }

            _background.Stop();
        }

        private void PlayEffectAudioSource_Internal(int index)
        {
            _effect.PlayOneShot(effectAudioClipData[index]);
        }

        private void SetBackgroundAudioSourceVolume_Internal(float value)
        {
            master.SetFloat(background.name, value);
        }

        private void SetEffectAudioSourceVolume_Internal(float value)
        {
            master.SetFloat(effect.name, value);
        }

        #region STATIC METHOD API

        /// <summary>
        /// Play background audio source.
        /// </summary>
        /// <param name="index"> Index of background audio clip. </param>
        public static void PlayBackgroundAudioSource(int index)
        {
            Instance.PlayBackgroundAudioSource_Internal(index);
        }

        /// <summary>
        /// Stop background audio source that is currently playing.
        /// </summary>
        public static void StopBackgroundAudioSource()
        {
            Instance.StopBackgroundAudioSource_Internal();
        }

        /// <summary>
        /// Play effect audio source.
        /// </summary>
        public static void PlayEffectAudioSource(int index)
        {
            Instance.PlayEffectAudioSource_Internal(index);
        }

        /// <summary>
        /// Set the volume value for background sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetBackgroundAudioVolume(float value)
        {
            Instance.SetBackgroundAudioSourceVolume_Internal(value);
        }
        
        /// <summary>
        /// Set the volume value for effect sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetEffectAudioVolume(float value)
        {
            Instance.SetEffectAudioSourceVolume_Internal(value);
        }

        #endregion
    }
}
