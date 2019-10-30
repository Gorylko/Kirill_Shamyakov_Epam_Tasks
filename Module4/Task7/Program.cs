using System;
using Task7.Sorters;

namespace Task7
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 18,12,42,7,6,455,7,3,21,14,47,8,345,1,234};

            array = (int[])array.Sort();

            Console.ReadKey();
        }
    }
}
