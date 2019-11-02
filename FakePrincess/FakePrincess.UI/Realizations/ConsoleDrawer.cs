using FakePrincess.General.Entities.Zone.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FakePrincess.General.Interfaces;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities;

namespace FakePrincess.UI.Realizations
{
    class ConsoleDrawer : IDisplay
    {
        public void DisplayAll(Zone displayZone)
        {
            if(displayZone == null)
            {
                return;
            }

            foreach(var cell in displayZone.Cells)
            {
                DisplayChar(GetMemberChar(cell.Member), cell.Position, GetMemberColor(cell.Member));
            }
        }

        private ConsoleColor GetMemberColor(IZoneMember member)
        {
            if(member is Wall)
            {
                return DrawerSettings.WallColor;
            }
            else if (member is Trap)
            {
                return DrawerSettings.TrapColor;
            }
            else if(member is Player)
            {
                return DrawerSettings.PayerColor;
            }
            return ConsoleColor.Green;
        }

        private char GetMemberChar(IZoneMember member)
        {
            if (member is Wall)
            {
                return DrawerSettings.WallChar;
            }
            else if (member is Trap)
            {
                return DrawerSettings.TrapChar;
            }
            else if (member is Player)
            {
                return DrawerSettings.PlayerChar;
            }
            return '.';
        }

        private void DisplayChar(char sym, Position position, ConsoleColor color = ConsoleColor.Green)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(position.Column, position.Row);
            Console.Write(sym);
            Console.ResetColor();
        }
    }
}
