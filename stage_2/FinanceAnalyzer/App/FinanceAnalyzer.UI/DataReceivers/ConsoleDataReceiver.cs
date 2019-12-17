using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.UI.Interfaces;
using System;
using System.Globalization;

namespace FinanceAnalyzer.UI.DataReceivers
{
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
    }
}
