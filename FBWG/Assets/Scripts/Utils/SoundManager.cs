using System;
using Backend.Data;
using Backend.Utils.Input;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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

        private UIControls _controls;
        private GameObject _settingsObject;
        
        protected override void OnAwake()
        {
            base.OnAwake();

            _background = transform.GetChild(0).GetComponent<AudioSource>();
            _effect = transform.GetChild(1).GetComponent<AudioSource>();

            _controls = new UIControls();
            
            _settingsObject = transform.GetChild(2).gameObject;
        }

        private void OnEnable()
        {
            _controls.Enable();
            _controls.Settings.Toggle.performed += Toggle;
        }

        protected override void OnStart()
        {
            base.OnStart();
            
            var volume = DataManager.UserData.BackgroundAudioSourceVolume;
            SetBackgroundAudioSourceVolume_Internal(volume);
            
            volume = DataManager.UserData.EffectAudioSourceVolume;
            SetEffectAudioSourceVolume_Internal(volume);
            
            _settingsObject.SetActive(false);
        }

        private void OnDisable()
        {
            _controls.Settings.Toggle.performed -= Toggle;
            _controls.Disable();
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
            master.SetFloat(background.name, Mathf.Log10(value) * 20);
        }

        private void SetEffectAudioSourceVolume_Internal(float value)
        {
            master.SetFloat(effect.name, Mathf.Log10(value) * 20);
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            var child = _settingsObject.transform.GetChild(3);
            
            var isActive = _settingsObject.activeInHierarchy;
            if (isActive)
            {
                ApplicationManager.Play();
                
                child.gameObject.SetActive(true);
                
                _settingsObject.SetActive(false);
            }
            else
            {
                ApplicationManager.Pause();

                child.gameObject.SetActive(SceneManager.GetActiveScene().buildIndex >= 2);
                
                _settingsObject.SetActive(true);
            }
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
        public static void SetBackgroundAudioSourceVolume(float value)
        {
            Instance.SetBackgroundAudioSourceVolume_Internal(value);
        }
        
        /// <summary>
        /// Set the volume value for effect sound.
        /// </summary>
        /// <param name="value"> Value of the volume. </param>
        public static void SetEffectAudioSourceVolume(float value)
        {
            Instance.SetEffectAudioSourceVolume_Internal(value);
        }

        #endregion
    }
}
