namespace FinanceAnalyzer.UI.DataReceivers
{
    using System;
    using System.Globalization;
    using FinanceAnalyzer.Shared.Enums;
    using FinanceAnalyzer.UI.Interfaces;

    public class ConsoleDataReceiver : IDataReceiver
    {
        public bool TryGetDecimal(out decimal number, bool isOnFreePlace = false)
        {
            if (!isOnFreePlace)
            {
                Console.SetCursorPosition(0, 1);
            }

            return decimal.TryParse(Console.ReadLine(), NumberStyles.Any, CultureInfo.InvariantCulture, out number);
        }

        public bool TryGetString(out string userInput, bool isOnFreePlace = false)
        {
            if (!isOnFreePlace)
            {
                Console.SetCursorPosition(0, 1);
            }

            userInput = Console.ReadLine();

            return IsNotSqlInjection(userInput);
        }

        public bool TryGetInt(out int number, bool isOnFreePlace = false)
        {
            if (!isOnFreePlace)
            {
                Console.SetCursorPosition(0, 1);
            }

            return int.TryParse(Console.ReadLine(), out number);
        }

        public ActionType GetAction()
        {
            TryGetInt(out var intResult, true);

            return (ActionType)intResult;
        }

        private bool IsNotSqlInjection(string input)
        {
            return !input.Contains(";");
        }
    }
}
