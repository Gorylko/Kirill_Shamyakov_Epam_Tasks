using FakePrincess.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.UI.Realizations
{
    public class FakePrincessSettings : Settings
    {
        private const int HpBarWidth = 15;
        public FakePrincessSettings()
        {
        }

        public override void PerformInitialSetup()
        {

            var changer = new WindowSizeChanger();

            changer.ChangeSize(this.ZoneWidth + HpBarWidth, this.ZoneHeight);

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
