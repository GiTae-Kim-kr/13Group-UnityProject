using UnityEngine;

namespace Backend.Object.UI
{
    public abstract class BaseButton : MonoBehaviour
    {
        #region COMPONENT FIELD API

        protected UnityEngine.UI.Button Button;

        #endregion
        
        protected virtual void Awake()
        {
            Button = GetComponent<UnityEngine.UI.Button>();
            Button.onClick.AddListener(Click);
        }
        
        /// <summary>
        /// Invokes when a user clicks the button and releases it
        /// </summary>
        protected abstract void Click();
        
        public UnityEngine.UI.Button.ButtonClickedEvent OnClick => Button.onClick;
    }
}