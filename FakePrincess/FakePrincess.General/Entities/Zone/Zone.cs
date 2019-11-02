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

            InitializeCells();

            Cells[1, 1].Member = player;
        }

        public void SpawnEntities()
        {
            var zoneLength = this.Cells.GetLength(0);
            var zoneWidth = this.Cells.GetLength(1);
            for (int i = 0; i < zoneLength; i++)
            {
                for (int j = 0; j < zoneWidth; j++)
                {
                    if (i == 0
                        || i == zoneLength - 1
                        || j == 0
                        || j == zoneWidth - 1)
                    {
                        this.Cells[i, j].Member = new Wall();
                        continue;
                    }

                }
            }
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

        public BeforeActionResult GetActionResult(Position position)
        {
            var member = GetMember(position);

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
