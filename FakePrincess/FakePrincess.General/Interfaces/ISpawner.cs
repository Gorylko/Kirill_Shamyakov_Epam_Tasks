using FakePrincess.General.Entities.Zone.Members;
using System.Collections.Generic;

namespace FakePrincess.General.Interfaces
{
    public interface ISpawner
    {
        void SpawnTerritory();

        void SpawnTraps(int estimatedTrapsNumber, int maxTrapDamage);

        void SpawnPrincess(Princess princess);

        void SpawnPlayer(Player player);

        void SpawnTraps(IReadOnlyCollection<Trap> traps);
    }
}
