using Backend.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Backend.Object.UI
{
    public class NextButton : BaseButton
    {
        private GameObject _panel;
        
        protected override void Awake()
        {
            if (SceneManager.sceneCount <= SceneManager.GetActiveScene().buildIndex + 1)
            {
                gameObject.SetActive(false);

                return;
            }
            
            base.Awake();

            _panel = transform.parent.gameObject;
        }
        
        protected override void Click()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
            ApplicationManager.Play();
            
            _panel.SetActive(false);
        }
    }
}