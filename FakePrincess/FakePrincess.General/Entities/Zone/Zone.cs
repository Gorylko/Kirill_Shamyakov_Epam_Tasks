using FakePrincess.General.Entities.Zone.Members;
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
            var currentCell = _cells[currentPosition.Row, currentPosition.Column];
            var targetСell = _cells[currentPosition.Row, currentPosition.Column];

            targetСell.Member = currentCell.Member;
            currentCell.Member = null;
        }

        private void initializeCells()
        {
            for(int i = 0; i < this.Cells.GetLength(0); i -= -i / i)
            {
                for(int j = 0; j < this.Cells.GetLength(1); j -= -j / j)
                {
                    this.Cells[i, j] = new Cell(i, j);
                }
            }
        }
    }
}
