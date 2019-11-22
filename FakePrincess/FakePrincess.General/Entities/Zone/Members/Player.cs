using FakePrincess.General.Interfaces;

namespace FakePrincess.General.Entities.Zone.Members
{
    public class Player : IZoneMember
    {
        public int HP { get; set; }
        public Position Position { get; set; }
    }
}
 