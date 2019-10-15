using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Shapes;

namespace Task4.Calculators
{
    public class GeometricCalculator
    {
        public GeometricCalculator(double area)
        {
            if(area != default(double))
            {
                this.GeneralArea = area;
            }

            Shapes = new List<Shape>
            {
                new Circle(),
                new Square(),
                new Triangle()
            };

            this.Initialize();
        }

        public double GeneralArea { get; set; }

        public IReadOnlyCollection<Shape> Shapes { get; set; }

        private void Initialize()
        {
            if(this.GeneralArea == default(double))
            {
                return;
            }

            foreach(var shape in Shapes)
            {
                shape.InitializeByArea(this.GeneralArea);
            }
        }

        public string GetFullInfo()
        {
            var builder = new StringBuilder();

            foreach(var shape in Shapes)
            {
                builder.AppendLine(shape.ToString() + "\n");
            }

            return builder.ToString();
        }
    }
}
