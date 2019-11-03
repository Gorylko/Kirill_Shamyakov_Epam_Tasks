using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;

namespace FakePrincess.General.Interfaces
{
    public interface IDisplay
    {
        void DisplayMessageForUser(string message);

        void DisplayAll(Zone displayZone, Player player);

        void Display(Position position, IZoneMember member);

        void DisplayHP(Position position, int hp);
    }
}
