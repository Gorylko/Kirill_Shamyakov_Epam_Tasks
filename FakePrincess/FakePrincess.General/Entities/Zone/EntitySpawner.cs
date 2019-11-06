using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;
using System.Collections.Generic;

namespace FakePrincess.General.Entities.Zone
{
    public class EntitySpawner : ISpawner
    {
        private Cell[,] _targetCells;
        private Random _randomTool;

        public EntitySpawner(Cell[,] cells)
        {
            this._targetCells = cells ?? throw new NullReferenceException(nameof(cells));
            this._randomTool = new Random();
        }

        public void SpawnTerritory()
        {
            var zoneLength = this._targetCells.GetLength(0);
            var zoneWidth = this._targetCells.GetLength(1);

            for (int i = 0; i < zoneLength; i++)
            {
                for (int j = 0; j < zoneWidth; j++)
                {
                    if (i == 0
                        || i == zoneLength - 1
                        || j == 0
                        || j == zoneWidth - 1)
                    {
                        this._targetCells[i, j].Member = new Wall();
                        continue;
                    }

                }
            }
        }

        public void PlaceTraps(IReadOnlyCollection<Trap> traps)
        {
            int row, column;

            foreach(var trap in traps)
            {
                row = this._randomTool.Next(1, this._targetCells.GetLength(0) - 1);
                column = this._randomTool.Next(1, this._targetCells.GetLength(1) - 1);
                if (!(this._targetCells[row, column].Member is Player || this._targetCells[row, column].Member is Trap)){
                    this._targetCells[row, column].Member = trap;
                }
            }
        }

        public void SpawnTraps(int estimatedTrapsNumber)
        {
            int row, column;

            for(int i = 0; i < estimatedTrapsNumber; i++)
            {
                row = this._randomTool.Next(1, this._targetCells.GetLength(0) - 1);
                column = this._randomTool.Next(1, this._targetCells.GetLength(1) - 1);
                if (!(this._targetCells[row, column].Member is Player || this._targetCells[row, column].Member is Trap))
                {
                    this._targetCells[row, column].Member = new Trap();
                }
            }
        }

        public void PlacePlayer(Player player)
        {
            if (player == null || player.Position == null)
            {
                return;
            }

            this._targetCells[player.Position.Row, player.Position.Column].Member = player;
        }

        public void PlacePrincess(Princess princess)
        {
            if(princess == null || princess.Position == null)
            {
                return;
            }

            this._targetCells[princess.Position.Row, princess.Position.Column].Member = princess;
        }
    }
}
