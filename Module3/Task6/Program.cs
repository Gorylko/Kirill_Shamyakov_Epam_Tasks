using System;

namespace Task6
{
    class Program
    {
        private const int ArrayLength = 10;
        static void Main(string[] args)
        {
            var arrayTrans = new ArrayTransformer();
            arrayTrans.RandomlyInitialize(ArrayLength);

            Console.WriteLine("Before");
            Console.WriteLine(arrayTrans + "\n");

            arrayTrans.InvertArray();

            Console.WriteLine("After");
            Console.WriteLine(arrayTrans);
            Console.ReadKey();
        }
    }
}