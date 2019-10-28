using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module.Helper;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleDataInitializer();

            var consoleInitializerResult = initializer.GetArrayInput();

            if (consoleInitializerResult.IsSuccessful)
            {
                
            }
        }
    }
}
