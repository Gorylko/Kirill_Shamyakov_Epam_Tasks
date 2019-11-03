using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Interfaces;
using System;
using System.Threading;

namespace FakePrincess.UI.Realizations
{
    class ConsoleController : IController
    {
        public ActionType GetAction()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    return ActionType.MoveUp;

                case ConsoleKey.RightArrow:
                    return ActionType.MoveRight;

                case ConsoleKey.DownArrow:
                    return ActionType.MoveDown;

                case ConsoleKey.LeftArrow:
                    return ActionType.MoveLeft;

                default:
                    return ActionType.Nothing;
            }
        }

        public bool IsReplay()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Repeat - press Enter");

            if(Console.ReadKey(true).Key == ConsoleKey.Enter)
            {
                return true;
            }

            return false;
        }
    }
}
