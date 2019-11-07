using FakePrincess.General.Entities.Zone.Members;
using System.Collections.Generic;

namespace FakePrincess.General.Interfaces
{
    public interface ISpawner
    {
        void SpawnTerritory();

        void SpawnTraps(int estimatedTrapsNumber, int maxTrapDamage);

        void PlacePrincess(Princess princess);

        void PlacePlayer(Player player);

        void PlaceTraps(IReadOnlyCollection<Trap> traps);
    }
}
