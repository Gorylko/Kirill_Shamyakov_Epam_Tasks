using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.DataInitializers.Params;
using Task4.Enums;

namespace Task4.DataInitializers
{
    public class ConsoleDataInitializer : IDataInitializer<GeometricCalculatorParams>
    {
        public ConsoleDataInitializer()
        {

        }

        public DataInitializerResult<GeometricCalculatorParams> InitializeData()
        {
            (var shapeType, var paramType) = GetUserInput();
            var convertedResult = ConvertUserInputToEnums(shapeType, paramType);

            if (!convertedResult.IsSuccessful)
            {
                return GetErrorResult(convertedResult.ErrorMessage);
            }

            switch (convertedResult.Parameters.ShapeType)
            {
                case ShapeType.Circle:
                    return GetCircleResult(convertedResult.Parameters.ParamType);

                case ShapeType.Square:
                    return GetSquareResult(convertedResult.Parameters.ParamType);

                case ShapeType.Triangle:
                    return GetTriangleResult(convertedResult.Parameters.ParamType);

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

        private DataInitializerResult<GeometricCalculatorParams> GetCircleResult(ParamType paramType)
        {

        }

        private DataInitializerResult<GeometricCalculatorParams> GetSquareResult(ParamType paramType)
        {

        }

        private DataInitializerResult<GeometricCalculatorParams> GetTriangleResult(ParamType paramType)
        {

        }

        private (string, string) GetUserInput()
        {
            Console.WriteLine("Choose a shape" + "\n" +
                                "1. Circle" + "\n" +
                                "2. Square" + "\n" +
                                "3. Triangle");

            string shapeTypeNumber = Console.ReadLine();

            Console.WriteLine("Choose a param" + "\n" +
                                "1. Area" + "\n" +
                                "2. Perimeter");

            string shapeParamNumber = Console.ReadLine();

            Console.Clear();

            return (shapeTypeNumber, shapeParamNumber);
        }

        private DataInitializerResult<UserInputParams> ConvertUserInputToEnums(string shapeTypeNumber, string shapeParamNumber)
        {
            if (Enum.TryParse(shapeTypeNumber, true, out ShapeType shapeTypeValue) &&
                Enum.TryParse(shapeParamNumber, true, out ParamType paramTypeValue))
            {
                return new DataInitializerResult<UserInputParams>
                {
                    Parameters = new UserInputParams
                    {
                        ParamType = paramTypeValue,
                        ShapeType = shapeTypeValue
                    },
                    IsSuccessful = true
                };
            }
            else
            {
                return new DataInitializerResult<UserInputParams>
                {
                    IsSuccessful = false,
                    ErrorMessage = "Invalid user input"
                };
            }
        }

    }
}
