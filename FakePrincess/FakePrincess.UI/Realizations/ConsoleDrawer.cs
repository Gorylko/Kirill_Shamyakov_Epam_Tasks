using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;

namespace FakePrincess.UI.Realizations
{
    class ConsoleDrawer : IDisplay
    {
        public void DisplayAll(Zone displayZone, Player player)
        {
            if(displayZone == null)
            {
                return;
            }

            foreach(var cell in displayZone.Cells)
            {
                DisplayChar(GetMemberChar(cell.Member), cell.Position, GetMemberColor(cell.Member));
            }

            DisplayHP(new Position
            {
                Row = DisplayerSettings.topIndent,
                Column = displayZone.Cells.GetLength(1) + 1
            }, player.HP);
        }

        private ConsoleColor GetMemberColor(IZoneMember member)
        {
            if(member is Wall)
            {
                return DisplayerSettings.WallColor;
            }
            else if (member is Trap)
            {
                return DisplayerSettings.TrapColor;
            }
            else if(member is Player)
            {
                return DisplayerSettings.PayerColor;
            }
            return ConsoleColor.Green;
        }

        private char GetMemberChar(IZoneMember member)
        {
            if(member == null)
            {
                return '.';
            }

            if (member is Wall)
            {
                return DisplayerSettings.WallChar;
            }
            else if (member is Trap)
            {
                return DisplayerSettings.TrapChar;
            }
            else if (member is Player)
            {
                return DisplayerSettings.PlayerChar;
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

        public void Display(Position position, IZoneMember member)
        {
            if(position == null)
            {
                throw new NullReferenceException(nameof(position));
            }

            DisplayChar(GetMemberChar(member), position, GetMemberColor(member));
        }

        public void DisplayHP(Position position, int hpAmount)
        {
            Console.SetCursorPosition(position.Column, position.Row);
            Console.ForegroundColor = DisplayerSettings.HpColor;
            Console.Write($"HP : {hpAmount}");
            Console.ResetColor();
        }

        public void DisplayMessageForUser(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
