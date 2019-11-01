using FakePrincess.General.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Entities.Zone
{
    public class Cell
    {
        public Position Position { get; set; }

        public IZoneMember Member { get; set; }

        public Cell(int row, int column)
        {
            this.Position = new Position
            {
                Row = row,
                Column = column
            };
        }
    }
}
