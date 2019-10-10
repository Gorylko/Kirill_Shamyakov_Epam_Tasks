using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Entities;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var initializer = new ConsoleInitializer();
            initializer.Initialize();
            var calculator = new TaxCalculator(initializer);



            Console.ReadKey();
        }
    }
}
