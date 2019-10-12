using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.DataInitializers.Params;

namespace Task1.DataInitializers
{
    public class ConsoleTaxDataInitializer : IDataInitializer<TaxCalculatorParams>
    {
        private const double Profit = 500;

        public DataInitializerResult<TaxCalculatorParams> InitializeData()
        {
            int companyCount;
            double tax;

            Console.WriteLine("Enter the number of companies");
            if (!int.TryParse(Console.ReadLine(), out companyCount) &&
                companyCount < 0)
            {
                return GetErrorResult($"Invalid value of {nameof(companyCount)}");
            }

            Console.WriteLine("Enter tax percentage");
            if (!double.TryParse(Console.ReadLine(), out tax) &&
                tax < 0 &&
                tax > 100)
            {
                return GetErrorResult($"Invalid value of {nameof(tax)}");
            }

            return new DataInitializerResult<TaxCalculatorParams>
            {
                Parameters = new TaxCalculatorParams
                {
                    CompanyCount = companyCount,
                    Profit = Profit,
                    TaxPercentage = tax
                },
                IsSuccessful = true,
            };


        }

        private DataInitializerResult<TaxCalculatorParams> GetErrorResult(string errorMessage)
        {
            return new DataInitializerResult<TaxCalculatorParams>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
