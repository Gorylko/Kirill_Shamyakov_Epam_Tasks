using FakePrincess.Logic;
using FakePrincess.UI.Realizations;
using System;

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
                ZoneWidth = 60
            };

            var game = new Game(new ConsoleController(), new ConsoleDisplayer(settings.ZoneHeight, settings.ZoneWidth), settings);

            game.Launch();

            Console.ReadKey();

        }
    }
}
