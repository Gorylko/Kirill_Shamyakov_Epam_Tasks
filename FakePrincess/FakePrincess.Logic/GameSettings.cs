using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.Logic
{
    public abstract class Settings
    {
        public int ZoneHeight { get; set; }

        public int ZoneWidth { get; set; }

        public int NumberOfTraps { get; set; }

        public int PlayerHP { get; set; }

        public abstract void ResetSettings();

        public abstract void PerformInitialSetup();
    }
}
