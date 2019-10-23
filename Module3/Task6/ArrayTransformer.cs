using System;
using System.Linq;
using System.Text;

namespace Task6
{
    public class ArrayTransformer
    {
        public int[] Array { get; set; }

        public void InvertArray()
        {
            this.Array = this.Array.Select(el => -el).ToArray();
        }

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach(var el in this.Array)
            {
                builder.Append($"{el} ");
            }

            return builder.ToString();
        }

        public void InitializeRandomly(int elemCount, int minValue = -100, int maxValue = 101)
        {
            if (elemCount < 1)
            {
                return;
            }

            var randomTool = new Random();
            this.Array = new int[elemCount];

            for (int i = 0; i < elemCount; i++)
            {
                this.Array[i] = randomTool.Next(minValue, maxValue);
            }

        }
    }
}
