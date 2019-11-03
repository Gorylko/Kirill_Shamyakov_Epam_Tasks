using FakePrincess.UI.Realizations.Params;
using System;
using System.Collections.Generic;

namespace FakePrincess.UI.Realizations
{
    public static class DisplayerSettings
    {
        public static Dictionary<string, DisplayParams> SettingsContainer = new Dictionary<string, DisplayParams>
        {
            {"wall", new DisplayParams{ Symbol = 'X', Color = ConsoleColor.Gray} },
            {"player", new DisplayParams{Symbol = '8', Color = ConsoleColor.Blue} },
            {"default-trap", new DisplayParams{Symbol =' ', Color = ConsoleColor.Red} },
            {"hp-bar", new DisplayParams{Color = ConsoleColor.Red } }
        };
    }
}
