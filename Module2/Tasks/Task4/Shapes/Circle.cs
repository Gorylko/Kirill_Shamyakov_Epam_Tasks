using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Shapes
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override void InitializeByArea(double area)
        {
            if(area == default(double))
            {
                return;
            }

            this.Area = area;
            this.Radius = Math.Sqrt(area / Math.PI);
            this.Perimeter = 2 * Math.PI * this.Radius;
        }

        public override string ToString()
        {
            return "***Circle***" + "\n" +
                    $"Radius : {this.Radius}\n" +
                    $"Perimeter : {this.Perimeter}\n" +
                    $"Area : {this.Area}\n";
        }
    }
}
