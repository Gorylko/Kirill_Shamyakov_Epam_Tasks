using FinanceAnalyzer.Shared.Enums;
using FinanceAnalyzer.Shared.Results;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IDataReceiver
    {
        DataResult<int> GetInt();

        DataResult<double> GetDouble();

        DataResult<ActionType> GetAction();
    }
}
