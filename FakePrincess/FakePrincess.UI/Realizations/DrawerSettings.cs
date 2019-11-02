using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakePrincess.UI.Realizations
{
    public static class DrawerSettings
    {
        public static char WallChar = 'X';
        public static ConsoleColor WallColor = ConsoleColor.Gray;

        public static char PlayerChar = '8';
        public static ConsoleColor PayerColor = ConsoleColor.Blue;

        public static char TrapChar = ' ';
        public static char ActivatedTrapChar = '<';
        public static ConsoleColor TrapColor = ConsoleColor.Red;

        public static ConsoleColor HpColor = ConsoleColor.Red;
        public static int topIndent = 2;
    }
}
