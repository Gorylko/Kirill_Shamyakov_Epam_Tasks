using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.Logic
{
    public class Game
    {
        private IController _controller;
        private IDrawer _drawer;
        private bool _isGameOn;

        public GameSettings Settings { get; set; }
        public Zone Zone { get; set; }

        public Game(IController controller, IDrawer drawer, GameSettings settings)
        {
            this._controller = controller ?? throw new NullReferenceException(nameof(controller));
            this._drawer = drawer ?? throw new NullReferenceException(nameof(drawer));
            this.Settings = settings ?? throw new NullReferenceException(nameof(settings));

            this.Zone = new Zone(settings.ZoneHeight, settings.ZoneWidth);
        }

        public void Launch()
        {
            this._isGameOn = true;

            while (this._isGameOn)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W | ConsoleKey.UpArrow:
                        break;
                    case ConsoleKey.D | ConsoleKey.RightArrow:
                        break;
                    case ConsoleKey.S | ConsoleKey.DownArrow:
                        break;
                    case ConsoleKey.A | ConsoleKey.LeftArrow:
                        break;
                }
            }
        }
    }
}
