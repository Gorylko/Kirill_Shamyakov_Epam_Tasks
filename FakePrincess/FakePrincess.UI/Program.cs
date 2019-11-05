using FakePrincess.General.Entities;
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
                PlayerHP = 1,
                ZoneHeight = 30,
                ZoneWidth = 60,
                PrincessPosition = new Position() { Row = 28, Column = 58}
            };

            var game = new Game(new ConsoleController(), new ConsoleDisplayer(settings.ZoneHeight, settings.ZoneWidth), settings);

            game.Launch();
        }
    }
}
