using Backend.Utils;
using UnityEngine;

namespace Backend.Object.UI
{
    public class StageSelectPanel : MonoBehaviour
    {
        private void Awake()
        {
            var length = DataManager.UserData.Stages.Length;

            for (var i = 0; i < length; i++)
            {
                var child = transform.GetChild(3 + i);
                var button = child.GetComponentInChildren<UnityEngine.UI.Button>();
                var images = child.GetComponentsInChildren<UnityEngine.UI.RawImage>();
                
                button.interactable = DataManager.UserData.Stages[i].Unlocked;
                
                for (var j = 0; j < 3; j++)
                {
                    images[j].enabled = false;
                }
                
                var count = DataManager.UserData.Stages[i].Score;
                for (var j = 0; j < count; j++)
                {
                    images[j].enabled = true;
                }
            }
        }
    }
}