using FinanceAnalyzer.Data.DataContext.Interfaces;
using FinanceAnalyzer.Shared.Results;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FinanceAnalyzer.Data.DataContext.Realizations
{
    public class IncomeContext : IIncomeContext<double> //Методы те же, что и в контексте расходов(лишний код, да, знаю), но при работе с бд эта проблема решается
        //просто создавая отдельный класс, для универсального выполнения хранимок, сделал с файлами для примера))
    {
        private const string FilePath = "income.txt";

        public void ClearAll()
        {
            File.WriteAllText(FilePath, string.Empty);
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
                        if (double.TryParse(line.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
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
