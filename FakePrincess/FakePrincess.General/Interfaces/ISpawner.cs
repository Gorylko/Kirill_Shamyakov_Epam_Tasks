using FakePrincess.General.Entities.Zone.Members;
using System.Collections.Generic;

namespace FakePrincess.General.Interfaces
{
    public interface ISpawner
    {
        void SpawnTerritory();

        void PlacePrincess(Princess princess);

        void PlacePlayer(Player player);

        void PlaceTraps(IReadOnlyCollection<Trap> traps);

        void SpawnTraps(int estimatedTrapsNumber);
    }
}
