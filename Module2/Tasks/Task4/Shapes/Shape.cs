using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.Shapes
{
    public abstract class Shape
    {
        public double Area { get; set; }

        public double Perimeter { get; set; }

        public abstract void InitializeByArea(double area);
    }
}
