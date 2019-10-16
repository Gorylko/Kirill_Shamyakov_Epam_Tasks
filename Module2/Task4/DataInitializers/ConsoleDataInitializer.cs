using System;
using System.Linq;
using System.Threading;
using Task4.DataInitializers.Params;
using Task4.Enums;

namespace Task4.DataInitializers
{
    public class ConsoleDataInitializer : IDataInitializer<GeometricCalculatorParams>
    {
        public DataInitializerResult<GeometricCalculatorParams> InitializeData()
        {
            var modeInputResult = GetUserSelectedMode();

            if (!modeInputResult.IsSuccessful)
            {
                return GetErrorResult(modeInputResult.ErrorMessage);
            }
            else if (modeInputResult.Param.ParamType == ParamType.Area)
            {
                return GetCalculatorParamByUserInput("Enter the area", ParamType.Area, "Invalid value of area");
            }

            var perimeterInputResult = GetCalculatorParamByUserInput("Enter the perimeter", ParamType.Perimeter, "Invalid value of perimeter");

            if (!perimeterInputResult.IsSuccessful)
            {
                GetErrorResult(perimeterInputResult.ErrorMessage);
            }

            switch (modeInputResult.Param.ShapeType)
                {
                    case ShapeType.Circle:
                        return GetResultByCirclePerimeter(perimeterInputResult.Parameters.Perimeter);

                    case ShapeType.Square:
                        return GetResultBySquarePerimeter(perimeterInputResult.Parameters.Perimeter);

                    case ShapeType.Triangle:
                        return GetResultByTrianglePerimeter(perimeterInputResult.Parameters.Perimeter);

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

        private DataInitializerResult<GeometricCalculatorParams> GetResultByCirclePerimeter(double perimeter)
        {
            return new DataInitializerResult<GeometricCalculatorParams>
            {
                Parameters = new GeometricCalculatorParams
                {
                    GeneralArea = Math.PI * Math.Pow(perimeter / (2 * Math.PI), 2)
                },
                IsSuccessful = true
            };
        }

        private DataInitializerResult<GeometricCalculatorParams> GetResultBySquarePerimeter(double perimeter)
        {
            return new DataInitializerResult<GeometricCalculatorParams>
            {
                Parameters = new GeometricCalculatorParams
                {
                    GeneralArea = Math.Pow((perimeter / 4), 2)
                },
                IsSuccessful = true
            };
        }

        private DataInitializerResult<GeometricCalculatorParams> GetResultByTrianglePerimeter(double perimeter)
        {
            return new DataInitializerResult<GeometricCalculatorParams>
            {
                Parameters = new GeometricCalculatorParams
                {
                    GeneralArea = Math.Sqrt(3) / 4 * Math.Pow(perimeter / 3, 2)
                },
                IsSuccessful = true
            };
        }

        private (string, string) GetUserModeInput()
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

        private UserInputResult<UserInputParams> GetUserSelectedMode()
        {
            (string shapeTypeNumber, string shapeParamNumber) = GetUserModeInput();

            if (Enum.TryParse(shapeTypeNumber, true, out ShapeType shapeTypeValue) &&
                Enum.TryParse(shapeParamNumber, true, out ParamType paramTypeValue))
            {
                return new UserInputResult<UserInputParams>
                {
                    Param = new UserInputParams
                    {
                        ParamType = paramTypeValue,
                        ShapeType = shapeTypeValue
                    },
                    IsSuccessful = true
                };
            }
            else
            {
                return new UserInputResult<UserInputParams>
                {
                    IsSuccessful = false,
                    ErrorMessage = "Invalid user input"
                };
            }
        }

        private DataInitializerResult<GeometricCalculatorParams> GetCalculatorParamByUserInput(
            string messageToUser, 
            ParamType paramType,
            string errorMessage = "Invalid value of user input")
        {
            Console.WriteLine(messageToUser);

            string stringNumber = Console.ReadLine();

            if (stringNumber.Contains('.') &&  // 2,3 == 2.3
                Thread.CurrentThread.CurrentCulture.IetfLanguageTag == "ru-RU")
            {
                stringNumber = stringNumber.Replace('.', ',');
            }

            if (double.TryParse(stringNumber, out double number) &&
                number != 0)
            {
                if(paramType == ParamType.Area)
                {
                    return new DataInitializerResult<GeometricCalculatorParams>
                    {
                        Parameters = new GeometricCalculatorParams
                        {
                            GeneralArea = number
                        },
                        IsSuccessful = true
                    };
                }
                else
                {
                    return new DataInitializerResult<GeometricCalculatorParams>
                    {
                        Parameters = new GeometricCalculatorParams
                        {
                            Perimeter = number
                        },
                        IsSuccessful = true
                    };
                }
            }

            return GetErrorResult(errorMessage);
        }

    }
}
