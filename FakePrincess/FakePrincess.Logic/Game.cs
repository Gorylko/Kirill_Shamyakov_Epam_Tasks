using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using FakePrincess.General.Entities.Results;
using System.Threading.Tasks;

namespace FakePrincess.Logic
{
    public class Game
    {
        private IController _controller;
        private IDrawer _drawer;
        private bool _isGameOn;

        public GameSettings Settings { get; set; }
        public Player Player { get; set; }
        public Zone Zone { get; set; }

        public Game(IController controller, IDrawer drawer, GameSettings settings)
        {
            this._controller = controller ?? throw new NullReferenceException(nameof(controller));
            this._drawer = drawer ?? throw new NullReferenceException(nameof(drawer));
            this.Settings = settings ?? throw new NullReferenceException(nameof(settings));

            this.Zone = new Zone(settings.ZoneHeight, settings.ZoneWidth);
            this.Player = new Player
            {
                Position = new Position
                {
                    Column = 1,
                    Row = 1
                },
                HP = settings.PlayerHP  
            };
        }

        public void Launch()
        {
            this._isGameOn = true;

            while (this._isGameOn)
            {
                var actionResult = GetActionResult(_controller.GetAction());

                UpdateCurrentPayerHP(actionResult);
                UpdateCurrentPlayerPosition(actionResult);
            }
        }

        private BeforeActionResult GetActionResult(ActionType actionType)
        {

        }

        private void UpdateCurrentPayerHP(BeforeActionResult actionResult)
        {
            if (actionResult.IsDamaged)
            {
                this.Player.HP--;
                
                if(Player.HP < 1)
                {
                    this._isGameOn = false;
                }
            }
        }

        private void UpdateCurrentPlayerPosition(BeforeActionResult actionResult)
        {
            if (!actionResult.IsCanMove)
            {
                return;
            }

            switch (actionResult.Action)
            {
                case ActionType.MoveUp: 
                    break;

                case ActionType.MoveRight:
                    break;

                case ActionType.MoveDown:
                    break;

                case ActionType.MoveLeft:
                    break;
            }
        }
    }
}
