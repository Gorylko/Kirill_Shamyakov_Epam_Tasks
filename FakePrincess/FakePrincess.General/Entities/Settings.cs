using FakePrincess.General.Entities;
using System;

namespace FakePrincess.General
{
    public abstract class Settings
    {
        private Position _startPlayerPosition;

        public int ZoneHeight { get; set; }

        public int ZoneWidth { get; set; }

        public int NumberOfTraps { get; set; }

        public int MaxTrapDamage { get; set; }

        public int PlayerHP { get; set; }

        public Position StartPlayerPosition
        {
            get => this._startPlayerPosition;

            set
            {
                this._startPlayerPosition = (value.Row >= 0 && value.Column >= 0)
                    ? value
                    : new Position
                    {
                        Row = Math.Abs(value.Row),
                        Column = Math.Abs(value.Column)
                    };
            }
        }

        public Position PrincessPosition { get; set; }

        public abstract void ResetSettings();

        public abstract void PerformInitialSetup();

    }
}
