using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.General.Interfaces.Realizations.Console
{
    public static class DrawerSettings
    {
        public static char WallChar = 'X';
        public static ConsoleColor WallColor = ConsoleColor.Gray;

        public static char PlayerChar = '8';
        public static ConsoleColor PayerColor = ConsoleColor.Blue;

        public static char TrapChar = ' ';
        public static ConsoleColor TrapColor = ConsoleColor.Red;
    }
}
