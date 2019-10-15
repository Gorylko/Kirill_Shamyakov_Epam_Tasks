using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Shapes
{
    public class Triangle : Shape
    {
        public override void InitializeByArea(double area)
        {
            if(area == default(double))
            {
                return;
            }

            this.Perimeter = Math.Sqrt((area * 4) / Math.Sqrt(3));
            this.Area = area;
        }

        public override string ToString()
        {
            return "***Circle***" + "\n" +
                    $"Perimeter : {this.Perimeter}\n" +
                    $"Area : {this.Area}\n";
        }
    }
}
