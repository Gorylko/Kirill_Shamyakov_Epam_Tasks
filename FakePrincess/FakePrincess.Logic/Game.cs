using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Entities.Results;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;

namespace FakePrincess.Logic
{
    public class Game
    {
        private IController _controller;
        private IDisplay _displayer;
        private bool _isGameOn;
        private bool _isPlayerWon;

        private Settings Settings { get; set; }
        private Player Player { get; set; }
        private Zone Zone { get; set; }

        public Game(IController controller, IDisplay drawer, Settings settings)
        {
            this._controller = controller ?? throw new NullReferenceException(nameof(controller));
            this._displayer = drawer ?? throw new NullReferenceException(nameof(drawer));
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
            this.Settings.PerformInitialSetup();

            this.Zone = new Zone(this.Player, settings.ZoneHeight, settings.ZoneWidth);
            this._displayer.DisplayAll(this.Zone, this.Player);
        }

        public void Launch()
        {
            this._isGameOn = true;
            try
            {
                while (this._isGameOn)
                {
                    var actionResult = GetActionResult(_controller.GetAction());

                    UpdateCurrentPayerHP(actionResult);
                    UpdateCurrentPlayerPosition(actionResult);
                }

            }
            catch(NullReferenceException ex)
            {
                this._displayer.DisplayMessageForUser($"The application crashed.\nReason : value of {ex.Message} is null");
            }
            catch(Exception ex)
            {
                this._displayer.DisplayMessageForUser($"The application crashed.\nReason : {ex.Message}");
            }
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
            }, actionType);
        }

        private void UpdateCurrentPayerHP(BeforeActionResult actionResult)
        {
            if (actionResult.IsDamaged)
            {
                this.Player.HP--;
                
                if(Player.HP < 1)
                {
                    this._isGameOn = false;
                    this._isPlayerWon = false;
                }
                this._displayer.DisplayHP(this.Player.HP);
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
                    this.Zone.RegisterMovement(
                        this.Player.Position, 
                        new Position
                        {
                            Row = this.Player.Position.Row - 1,
                            Column = this.Player.Position.Column
                        },
                        this._displayer.Display);
                    break;

                case ActionType.MoveRight:
                    this.Zone.RegisterMovement(this.Player.Position, new Position
                    {
                        Row = this.Player.Position.Row,
                        Column = this.Player.Position.Column + 1
                    },
                        this._displayer.Display);
                    break;

                case ActionType.MoveDown:
                    this.Zone.RegisterMovement(this.Player.Position, new Position
                    {
                        Row = this.Player.Position.Row + 1,
                        Column = this.Player.Position.Column
                    },
                        this._displayer.Display);
                    break;

                case ActionType.MoveLeft:
                    this.Zone.RegisterMovement(this.Player.Position, new Position
                    {
                        Row = this.Player.Position.Row,
                        Column = this.Player.Position.Column - 1
                    },
                        this._displayer.Display);
                    break;
            }
        }
    }
}
