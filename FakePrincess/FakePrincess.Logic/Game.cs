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
        private Princess Princess { get; set; }
        private Zone Zone { get; set; }

        public Game(IController controller, IDisplay drawer, Settings settings)
        {
            this._controller = controller ?? throw new NullReferenceException(nameof(controller));
            this._displayer = drawer ?? throw new NullReferenceException(nameof(drawer));
            this.Settings = settings ?? throw new NullReferenceException(nameof(settings));
        }

        public void Launch()
        {
            this._isGameOn = true;
            try
            {
                InitializeGame();
                while (this._isGameOn)
                {
                    var actionResult = GetActionResult(_controller.GetAction());

                    UpdateCurrentPayerHP(actionResult);
                    UpdateCurrentPlayerPosition(actionResult);
                    CheckIsWon(actionResult);
                }

                if (this._isPlayerWon)
                {
                    this._displayer.DisplayMessageForUser("Congratulations on the victory!!!");
                }
                else
                {
                    this._displayer.DisplayMessageForUser("Losing :-( Lucky another time");
                }
                ShowGameEndMenu();
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

        private void InitializeGame()
        {
            this.Player = new Player
            {
                Position = new Position
                {
                    Column = 1,
                    Row = 1
                },
                HP = this.Settings.PlayerHP
            };
            this.Princess = new Princess
            {
                Position = Settings.PrincessPosition
            };
            this.Settings.PerformInitialSetup();

            this.Zone = new Zone(this.Player, this.Princess, this.Settings.ZoneHeight, this.Settings.ZoneWidth);
            this._displayer.DisplayAll(this.Zone, this.Player);
        }

        private void CheckIsWon(BeforeActionResult actionResult)
        {
            if (actionResult.IsGameWone)
            {
                this._isGameOn = false;
                this._isPlayerWon = true;
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
            if (!actionResult.IsDamaged)
            {
                return;
            }

            this.Player.HP--;
                
            if(Player.HP < 1)
            {
                this._isGameOn = false;
                this._isPlayerWon = false;
            }
            this._displayer.DisplayHP(this.Player.HP);
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

        private void ShowGameEndMenu()
        {
            if (this._controller.IsReplay())
            {
                Launch();
            }
        }
    }
}
