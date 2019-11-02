using FakePrincess.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.UI.Realizations
{
    class FakePrincessSettings : GameSettings
    {
        public FakePrincessSettings()
        {
        }

        public override void PerformInitialSetup()
        {
            Console.CursorVisible = false;
        }

        public override void ResetSettings()
        {
            Console.CursorVisible = true;
            Console.Clear();
            Console.SetCursorPosition(0, 0);
        }
    }
}
