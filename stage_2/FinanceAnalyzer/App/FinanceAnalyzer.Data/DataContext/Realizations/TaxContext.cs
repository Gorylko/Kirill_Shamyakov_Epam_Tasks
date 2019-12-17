using FinanceAnalyzer.Data.DataContext.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class TaxContext : ITaxContext<decimal>
    {
        private const string FilePath = "tax.txt";

        public async Task ClearAll()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            throw new System.NotImplementedException();
        }


        public async Task Save(decimal obj)
        {
            using (var streamWriter = new StreamWriter(FilePath, true, Encoding.Default))
            {
                await streamWriter.WriteLineAsync(obj.ToString());
            }
        }
    }
}
