using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DataInitializers.Params;

namespace Task4.DataInitializers
{
    public class ConsoleDataInitializer : IDataInitializer<GeometricCalculatorParams>
    {
        public ConsoleDataInitializer()
        {

        }

        public DataInitializerResult<GeometricCalculatorParams> InitializeData()
        {
            Console.WriteLine("Choose a shape" + "\n" +
                                "1. Circle" + "\n" +
                                "2. Square" + "\n" +
                                "3. Triangle");
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                default:
                    return GetErrorResult("Invalid value of shape number");
            }
        }

        private DataInitializerResult<GeometricCalculatorParams> GetErrorResult(string errorMessage)
        {
            return new DataInitializerResult<GeometricCalculatorParams>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
