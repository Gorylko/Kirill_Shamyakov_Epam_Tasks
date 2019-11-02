using FakePrincess.UI.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
