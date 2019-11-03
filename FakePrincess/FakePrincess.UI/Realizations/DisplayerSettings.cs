﻿using FakePrincess.UI.Realizations.Params;
using System;
using System.Collections.Generic;

namespace FakePrincess.UI.Realizations
{
    public static class DisplayerSettings
    {
        public static Dictionary<string, DisplayEntityParams> EntityParams = new Dictionary<string, DisplayEntityParams>
        {
            {"wall", new DisplayEntityParams{ Symbol = 'X', Color = ConsoleColor.Gray} },
            {"player", new DisplayEntityParams{Symbol = '8', Color = ConsoleColor.Blue} },
            {"default-trap", new DisplayEntityParams{Symbol ='o', Color = ConsoleColor.Red} },
            {"hp-bar", new DisplayEntityParams{Color = ConsoleColor.Red } }
        };

        public static int TopIndent = 2;
    }
}
