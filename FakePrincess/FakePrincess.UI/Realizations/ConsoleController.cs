using FakePrincess.General.Entities.Enums;
using FakePrincess.General.Interfaces;
using System;

namespace FakePrincess.UI.Realizations
{
    class ConsoleController : IController
    {
        public ActionType GetAction()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.W | ConsoleKey.UpArrow:
                    return ActionType.MoveUp;

                case ConsoleKey.D | ConsoleKey.RightArrow:
                    return ActionType.MoveRight;

                case ConsoleKey.S | ConsoleKey.DownArrow:
                    return ActionType.MoveDown;

                case ConsoleKey.A | ConsoleKey.LeftArrow:
                    return ActionType.MoveLeft;

                default:
                    return ActionType.Nothing;
            }
        }
    }
}
