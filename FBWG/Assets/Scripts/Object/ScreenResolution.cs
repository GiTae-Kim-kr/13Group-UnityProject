using UnityEngine;

namespace Backend.Object
{
    public class ScreenResolution : MonoBehaviour
    {
        private void Start()
        {
            SetResolution();
        }
        
        private void SetResolution()
        {
            var resolution = new Resolution(1920, 1080);
            var device = new Resolution(Screen.width, Screen.height);
            
            Screen.SetResolution(resolution.Width, (int)((float)device.Width / device.Height) * resolution.Width, true);

            if ((float)resolution.Width / resolution.Height < (float)device.Width / device.Height)
            {
                var width = (float)resolution.Width / resolution.Height / ((float)device.Width / device.Height);

                if (Camera.main is null == false)
                {
                    Camera.main.rect = new Rect((1f - width) / 2f, 0f, width, 1f);
                }
            }
            else
            {
                var height = (float)device.Width / device.Height / ((float)resolution.Width / resolution.Height);

                if (Camera.main is null == false)
                {
                    Camera.main.rect = new Rect(0f, (1f - height) / 2f, 1f, height);
                }
            }
        }

        private struct Resolution
        {
            public readonly int Width;
            public readonly int Height;

            public Resolution(int width, int height)
            {
                Width = width;
                Height = height;
            }
        }
    }
}