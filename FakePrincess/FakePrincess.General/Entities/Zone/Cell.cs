using FakePrincess.General.Interfaces;

namespace FakePrincess.General.Entities.Zone
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            this.Position = new Position
            {
                Row = row,
                Column = column
            };
        }

        public Position Position { get; set; }

        public IZoneMember Member { get; set; }
    }
}
