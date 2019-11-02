using FakePrincess.General.Entities.Results;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Entities.Zone
{
    public class Zone
    {
        private const int MinWidth = 10;
        private const int MinHeight = 10;

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
                    ? value : new Cell[MinHeight, MinWidth];
            }
        }

        public Zone(Player player, int zoneHeight = 10, int zoneWidth = 10)
        {
            Cells = new Cell[zoneHeight, zoneWidth];

            initializeCells();



            Cells[1, 1].Member = player;
        }

        public void Move(Position currentPosition, Position newPosition)
        {
            if(GetMember(currentPosition) is Player player)
            {
                player.Position = newPosition;
            }

            var currentCell = _cells[currentPosition.Row, currentPosition.Column];
            var targetСell = _cells[currentPosition.Row, currentPosition.Column];

            targetСell.Member = currentCell.Member;
            currentCell.Member = null;
        }

        public BeforeActionResult GetActionResult(Position currentPosition, int verticalStep, int horizontalStep)
        {
            var member = GetMember(new Position {
                Row = currentPosition.Row + verticalStep,
                Column = currentPosition.Column + horizontalStep
            });

            return new BeforeActionResult
            {
                IsCanMove = member == null || member is Trap ? true : false,
                IsDamaged = member != null && member is Trap ? true : false
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

        private void initializeCells()
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
