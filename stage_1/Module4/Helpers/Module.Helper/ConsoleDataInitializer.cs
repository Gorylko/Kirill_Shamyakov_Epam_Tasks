using Module.Helper.Results;
using System;
using System.Linq;

namespace Module.Helper
{
    public class ConsoleDataInitializer
    {
        public UserInputResult<int[]> GetIntArray(string messageForUser = "Enter the array")
        {
            Console.WriteLine(messageForUser);

            var array = Console.ReadLine()
                .Split(' ')
                .Where(x => int.TryParse(x.ToString(), out int intEl))
                .Select(x => int.Parse(x.ToString())).ToArray();

            return array.Length == 0 ?
                GetErrorResult<int[]>("Invalid value of user input") :
                new UserInputResult<int[]>
                {
                    IsSuccessful = true,
                    Value = array
                };
        }

        public UserInputResult<int> GetIntNumber(string messageForUser = "Enter the int number")
        {
            Console.WriteLine(messageForUser);

            if(int.TryParse(Console.ReadLine(), out int number))
            {
                return new UserInputResult<int>
                {
                    Value = number,
                    IsSuccessful = true
                };
            }
            return GetErrorResult<int>("Invalid value of user input");
        }

        private UserInputResult<T> GetErrorResult<T>(string errorResult)
        {
            return new UserInputResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorResult
            };
        }
    }
}
