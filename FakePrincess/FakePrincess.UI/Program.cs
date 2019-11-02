using FakePrincess.Logic;
using FakePrincess.UI.Realizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var settings = new FakePrincessSettings
            {
                NumberOfTraps = 20,
                PlayerHP = 5,
                ZoneHeight = 30,
                ZoneWidth = 60
            };

            var changer = new WindowSizeChanger();
            changer.ChangeSize(settings.ZoneHeight, settings.ZoneWidth + 20);

            var game = new Game(new ConsoleController(), new ConsoleDrawer(), settings);

            game.Launch();
        }
    }
}
