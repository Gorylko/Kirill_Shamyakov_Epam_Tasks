using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Interfaces
{
    public interface ISpawner
    {
        void SpawnTerritory();

        Princess SpawnPrincess();

        void SpawnPlayer(Player player);

        void SpawnTraps(IReadOnlyCollection<Trap> traps);
    }
}
