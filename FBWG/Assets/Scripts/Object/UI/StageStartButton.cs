using Backend.Utils;

namespace Backend.Object.UI
{
    public class StageStartButton : BaseButton
    {
        protected override void Awake()
        {
            base.Awake();
            
            ApplicationManager.Pause();
        }

        protected override void Click()
        {
            ApplicationManager.Play();
        }
    }
}