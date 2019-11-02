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
        private IDisplay _drawer;
        private bool _isGameOn;

        private GameSettings Settings { get; set; }
        private Player Player { get; set; }
        private Zone Zone { get; set; }

        public Game(IController controller, IDisplay drawer, GameSettings settings)
        {
            this._controller = controller ?? throw new NullReferenceException(nameof(controller));
            this._drawer = drawer ?? throw new NullReferenceException(nameof(drawer));
            this.Settings = settings ?? throw new NullReferenceException(nameof(settings));

            this.Player = new Player
            {
                Position = new Position
                {
                    Column = 1,
                    Row = 1
                },
                HP = settings.PlayerHP  
            };

            this.Zone = new Zone(this.Player, settings.ZoneHeight, settings.ZoneWidth);
            this.Zone.SpawnEntities();
            this._drawer.DisplayAll(this.Zone);
        }

        public void Launch()
        {
            this._isGameOn = true;

            this.Settings.PerformInitialSetup();

            while (this._isGameOn)
            {
                var actionResult = GetActionResult(_controller.GetAction());

                UpdateCurrentPayerHP(actionResult);
                UpdateCurrentPlayerPosition(actionResult);
            }

            this.Settings.ResetSettings();
        }

        private BeforeActionResult GetActionResult(ActionType actionType)
        {
            int verticalStep = 0;
            int horizontalStep = 0;

            switch (actionType)
            {
                case ActionType.MoveUp:
                    verticalStep = -1;
                    break;
                case ActionType.MoveRight:
                    horizontalStep = +1;
                    break;

                case ActionType.MoveDown:
                    verticalStep = +1;
                    break;

                case ActionType.MoveLeft:
                    horizontalStep = -1;
                    break;

                default:
                    break;
            }

            return this.Zone.GetActionResult(new Position
            {
                Row = this.Player.Position.Row + verticalStep,
                Column = this.Player.Position.Column + horizontalStep
            });
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
