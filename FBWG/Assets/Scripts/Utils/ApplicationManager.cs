using UnityEngine;

namespace Backend.Utils
{
    public class ApplicationManager : Singleton<ApplicationManager>
    {
        private bool _isPaused;

        private ApplicationManager()
        {
            _isPaused = false;
        }

        private void Pause_Internal()
        {
            if (_isPaused)
            {
                return;
            }

            Time.timeScale = 0f;

            _isPaused = true;
        }

        private void Play_Internal()
        {
            if (_isPaused == false)
            {
                return;
            }

            Time.timeScale = 1f;

            _isPaused = false;
        }

        private void Quit_Internal()
        {
#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

#else

            UnityEngine.Application.Quit();

#endif
        }
        
        #region STATIC METHOD API
        
        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void Pause()
        {
            Instance.Pause_Internal();
        }

        /// <summary>
        /// Play the paused application.
        /// </summary>
        public static void Play()
        {
            Instance.Play_Internal();
        }

        /// <summary>
        /// Quits the player application.
        /// </summary>
        public static void Quit()
        {
            Instance.Quit_Internal();
        }

        #endregion

        #region STATIC PROPERTIES API

        public static bool IsPaused => Instance._isPaused;

        #endregion
    }
}
