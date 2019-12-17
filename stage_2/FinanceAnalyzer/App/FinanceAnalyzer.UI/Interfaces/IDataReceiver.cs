using FinanceAnalyzer.Shared.Enums;

namespace FinanceAnalyzer.UI.Interfaces
{
    internal interface IDataReceiver
    {
        bool TryGetInt(out int number, bool isOnFreePlace = false);

        bool TryGetDecimal(out decimal number, bool isOnFreePlace = false);

        ActionType GetAction();
    }
}
