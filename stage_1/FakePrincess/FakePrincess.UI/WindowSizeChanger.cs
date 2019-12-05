using System;

namespace FakePrincess.UI
{
    public class WindowSizeChanger
    {
        public void ChangeSize(int width, int height)
        {
            if (Console.WindowHeight < height || Console.WindowWidth < width)
            {
                Console.SetWindowSize(width, height);
                Console.SetBufferSize(width, height);
            }
            else
            {
                Console.SetWindowSize(width, height);
                Console.SetBufferSize(width, height);
            }
        }
    }
}
