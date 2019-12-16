using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;
using System.Threading.Tasks;

namespace FinanceAnalyzer.UI.Interfaces
{
    internal interface IDataReceiver
    {
        DataResult<int> GetInt();

        DataResult<decimal> GetDecimal();

        DataResult<ActionType> GetAction();
    }
}
