using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Business.Services.Interfaces
{
    public interface ITaxService : IService<decimal, IReadOnlyCollection<decimal>>
    {
        Task<decimal> TakeTax(decimal income);
    }
}
