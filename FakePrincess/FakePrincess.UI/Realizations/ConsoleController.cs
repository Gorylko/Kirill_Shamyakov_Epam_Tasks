using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Interfaces;
using System;

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
            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        return true;
                    case ConsoleKey.Escape:
                        return false;
                    default:
                        continue;
                }
            }
        }
    }
}
