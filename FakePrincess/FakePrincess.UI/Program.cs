using FakePrincess.Logic;
using FakePrincess.UI.Realizations;

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

            var game = new Game(new ConsoleController(), new ConsoleDrawer(settings.ZoneHeight, settings.ZoneWidth), settings);

            game.Launch();
        }
    }
}
