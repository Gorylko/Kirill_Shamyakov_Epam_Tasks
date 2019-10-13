﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task4.Shapes;

namespace Task4.Calculators
{
    public class GeometricCalculator
    {
        public GeometricCalculator()
        {
            Shapes = new List<Shape>
            {
                new Circle(),
                new Square(),
                new Triangle()
            };
        }

        public double GeneralArea { get; set; }

        public IReadOnlyCollection<Shape> Shapes { get; set; }

        public void Initialize()
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

        public override string ToString()
        {
            var builder = new StringBuilder();

            foreach(var shape in Shapes)
            {
                builder.AppendLine($"***{nameof(shape)}***\n" +
                    $"Area: {shape.Area}\n" +
                    $"Perimeter: {shape.Perimeter}\n");
            }

            return builder.ToString();
        }
    }
}
