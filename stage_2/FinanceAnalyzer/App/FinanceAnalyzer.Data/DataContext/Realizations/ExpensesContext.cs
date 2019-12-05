using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Globalization;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class ExpensesContext : IExpensesContext<double> //Методы те же, что и в контексте доходов, но при работе с бд эта проблема решается, сделал с файлами для примера))
    {
        private const string FilePath = "expenses.txt";
        public void ClearAll()
        {
            throw new NotImplementedException();
        }

        public DataResult<IReadOnlyCollection<double>> GetAll()
        {
            var collection = new List<double>();
            using (var fileStream = new FileStream(FilePath, FileMode.OpenOrCreate))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                        {
                            collection.Add(number);
                        }
                    }

                    return new DataResult<IReadOnlyCollection<double>>
                    {
                        IsSuccessful = true,
                        Value = collection
                    };
                }
            }
        }

        public void Save(double obj)
        {
            using (StreamWriter sw = new StreamWriter(FilePath, true, Encoding.Default))
            {
                sw.WriteLine(obj.ToString());
            }
        }
    }
}
