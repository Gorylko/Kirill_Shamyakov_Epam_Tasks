using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Interfaces
{
    public interface IDisplay
    {
        void DisplayAll(Zone displayZone, Player player);

        void Display(Position position, IZoneMember member);

        void DisplayHP(Position position, int hp);
    }
}
