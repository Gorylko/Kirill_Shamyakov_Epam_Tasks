namespace FinanceAnalyzer.Business.Services.Interfaces
{
    using System.Collections.Generic;

    public interface IExpensesService : IService<decimal, IReadOnlyCollection<decimal>> { }
}
