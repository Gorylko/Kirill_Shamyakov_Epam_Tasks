using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Initializers;
using Task5.Initializers.Params;

namespace Task5.Initializers
{
    public class UserInputInitializer
    {
        public UserInputResult<UserInputParams> InitializeData()
        {

            Console.WriteLine("Enter the int number greater then 0");

            if (!int.TryParse(Console.ReadLine(), out int userNumber ) ||
                userNumber <= 0)
            {
                return GetErrorResult("Main number is not valid");
            }

            Console.WriteLine("Enter the number you want to delete");
            if(!int.TryParse(Console.ReadLine(), out int numberToDelete) ||
                numberToDelete <= 0)
            {
                return GetErrorResult("Number to delete is not valid");
            }
            return new UserInputResult<UserInputParams>
            {
                Parameters = new UserInputParams
                {
                    Number = userNumber,
                    NumberToDelete = numberToDelete
                },
                IsSuccessful = true
            };

        }

        private UserInputResult<UserInputParams> GetErrorResult(string errorMessage)
        {
            return new UserInputResult<UserInputParams>
            {
                ErrorMessage = errorMessage,
                IsSuccessful = false
            };
        }
    }
}
