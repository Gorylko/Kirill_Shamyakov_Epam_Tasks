using Module.Helper.Results;
using System;
using System.Linq;

namespace Module.Helper
{
    public class ConsoleDataInitializer
    {
        public UserInputResult<int[]> GetIntArray()
        {
            Console.WriteLine("Enter the array");

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
