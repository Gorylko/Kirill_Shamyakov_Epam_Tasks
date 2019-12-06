using FinanceAnalyzer.Data.DataContext.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MapStrategies = FinanceAnalyzer.Data.Mappers.DoubleCollectionMapStrategies;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class ExpensesContext : IExpensesContext<double>
    {
        private const string FilePath = "expenses.txt";

        public void ClearAll()
        {
            File.WriteAllText(FilePath, string.Empty);
        }

        public IReadOnlyCollection<double> GetAll()
        {
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    return MapStrategies.MapDoubles(streamReader.ReadToEnd());
                }
            }
        }

        public void Save(double obj)
        {
            using (var streamWriter = new StreamWriter(FilePath, true, Encoding.Default))
            {
                streamWriter.WriteLine(obj);
            }
        }
    }
}
