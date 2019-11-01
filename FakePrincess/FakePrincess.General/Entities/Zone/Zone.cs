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
                return this.Cells;
            }
            set
            {
                this._cells = value.GetLength(0) >= MinHeight && value.GetLength(1) >= MinWidth
                    ? value : new Cell[MinHeight, MinWidth];
            }
        }

        public Zone(int zoneHeight = 10, int zoneWidth = 10)
        {
            Cells = new Cell[zoneHeight, zoneWidth];
        }
    }
}
