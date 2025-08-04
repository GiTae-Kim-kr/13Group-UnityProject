using Backend.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Backend.Object.UI
{
    public class RestartButton : BaseButton
    {
        private GameObject _panel;
        
        protected override void Awake()
        {
            base.Awake();

            _panel = transform.parent.gameObject;
        }
        
        protected override void Click()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            ApplicationManager.Play();
            
            _panel.SetActive(false);
        }
    }
}