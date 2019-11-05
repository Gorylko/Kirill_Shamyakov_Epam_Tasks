using FakePrincess.General.Entities;
using FakePrincess.General.Entities.Zone;
using FakePrincess.General.Entities.Zone.Members;
using FakePrincess.General.Interfaces;
using System;

namespace FakePrincess.UI.Realizations
{
    class ConsoleDisplayer : IDisplay
    {
        private int _gameZoneHeight;
        private int _gameZoneWidth;

        public ConsoleDisplayer(int zoneHeight, int zoneWidth)
        {
            this._gameZoneHeight = zoneHeight;
            this._gameZoneWidth = zoneWidth;
        }

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

            DisplayTitle();
            DisplayHP(player.HP);
        }

        private void DisplayTitle()
        {
            var position = new Position() { Row = 0, Column = this._gameZoneWidth + 2 };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(position.Column, position.Row);
            Console.Write("FakePrincess");
            Console.ResetColor();
        }

        private ConsoleColor GetMemberColor(IZoneMember member)
        {
            if (member is Wall)
            {
                return DisplayerSettings.EntityParams["wall"].Color;
            }
            else if (member is Trap)
            {
                return DisplayerSettings.EntityParams["default-trap"].Color;
            }
            else if (member is Player)
            {
                return DisplayerSettings.EntityParams["player"].Color;
            }
            else if (member is Princess)
            {
                return DisplayerSettings.EntityParams["princess"].Color;
            }
            return DisplayerSettings.EntityParams["default"].Color;
        }

        private char GetMemberChar(IZoneMember member)
        {
            if(member == null)
            {
                return DisplayerSettings.EntityParams["default"].Symbol;
            }

            if (member is Wall)
            {
                return DisplayerSettings.EntityParams["wall"].Symbol;
            }
            else if (member is Trap)
            {
                return DisplayerSettings.EntityParams["default-trap"].Symbol;
            }
            else if (member is Player)
            {
                return DisplayerSettings.EntityParams["player"].Symbol;
            }
            else if (member is Princess)
            {
                return DisplayerSettings.EntityParams["princess"].Symbol;
            }

            return '?';
        }

        private void DisplayChar(char sym, Position position, ConsoleColor color)
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

        public void DisplayHP(int hpAmount)
        {
            var position = new Position() { Row = DisplayerSettings.TopIndent, Column = this._gameZoneWidth + 2 };
            Console.SetCursorPosition(position.Column, position.Row);
            Console.ForegroundColor = DisplayerSettings.EntityParams["hp-bar"].Color;
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
