using System.Collections.Generic;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface IIncomeService : IService<decimal, IReadOnlyCollection<decimal>> { }
}
