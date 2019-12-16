using FinanceAnalyzer.Data.DataContext.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MapStrategies = FinanceAnalyzer.Data.Mappers.DoubleCollectionMapStrategies;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class IncomeContext : IIncomeContext<decimal>
    {
        private const string FilePath = "income.txt";

        public async Task ClearAll()
        {
            await File.WriteAllTextAsync(FilePath, string.Empty);
        }

        public async Task<IReadOnlyCollection<decimal>> GetAll()
        {
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var data = await streamReader.ReadToEndAsync();
                    return MapStrategies.MapDecimalCollection(data);
                }
            }
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
