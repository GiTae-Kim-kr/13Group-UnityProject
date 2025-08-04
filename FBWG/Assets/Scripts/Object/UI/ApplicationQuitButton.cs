using Backend.Utils;

namespace Backend.Object.UI
{
    public class ApplicationQuitButton : BaseButton
    {
        protected override void Click()
        {
            ApplicationManager.Quit();
        }
    }
}