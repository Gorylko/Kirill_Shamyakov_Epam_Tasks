using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Entities.Results;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;

namespace FakePrincess.General.Entities.Zone
{
    public class Zone
    {
        private const int MinWidth = 10;
        private const int MinHeight = 10;

        private ISpawner _spawner;
        private Cell[,] _cells;

        public Cell[,] Cells
        {
            get
            {
                return this._cells;
            }
            set
            {
                this._cells = value.GetLength(0) >= MinHeight && value.GetLength(1) >= MinWidth
                    ? value
                    : new Cell[MinHeight, MinWidth];
            }
        }

        public Zone(Settings settings, Player player, Princess princess)
        {
            Cells = new Cell[settings.ZoneHeight, settings.ZoneWidth];

            this._spawner = new EntitySpawner(this.Cells);

            InitializeCells();

            this._spawner.SpawnTerritory();
            this._spawner.SpawnTraps(settings.NumberOfTraps, settings.MaxTrapDamage);
            this._spawner.SpawnPlayer(player);
            this._spawner.SpawnPrincess(princess);
        }

        public void RegisterMovement(Position currentPosition, Position newPosition, Action<Position, IZoneMember> displayAfterMove)
        {
            if(GetMember(currentPosition) is Player player)
            {
                player.Position = newPosition;
            }

            var currentCell = _cells[currentPosition.Row, currentPosition.Column];
            var targetСell = _cells[newPosition.Row, newPosition.Column];

            targetСell.Member = currentCell.Member;
            currentCell.Member = null;

            displayAfterMove(currentPosition, currentCell.Member);
            displayAfterMove(newPosition, targetСell.Member);
        }

        public BeforeActionResult GetActionResult(Position position, ActionType actionType)
        {
            if(position == null)
            {
                return new BeforeActionResult();
            }

            var member = GetMember(position);

            return new BeforeActionResult
            {
                Action = actionType,
                IsCanMove = member == null || member is Trap ? true : false,
                IsDamaged = member != null && member is Trap ? true : false,
                IsGameWone = member != null && member is Princess ? true : false,
                Damage = (member != null && member is Trap trap) ? trap.Damage : default
            };
        }

        public bool IsCellFree(Position position)
        {
            if(position == null)
            {
                return false;
            }

            var member = GetMember(position);

            return member == null
                || member is Trap;
        }

        private void InitializeCells()
        {
            for(int i = 0; i < this.Cells.GetLength(0); i++)
            {
                for(int j = 0; j < this.Cells.GetLength(1); j++)
                {
                    this.Cells[i, j] = new Cell(i, j);
                }
            }
        }

        private IZoneMember GetMember(Position memberPosition)
        {
            if(memberPosition == null)
            {
                return null;
            }

            return this.Cells[memberPosition.Row, memberPosition.Column].Member;
        }
    }
}
