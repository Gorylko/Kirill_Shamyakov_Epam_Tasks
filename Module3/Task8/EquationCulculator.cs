using System;

namespace Task8
{
    public class EquationCulculator
    {
        public EquationCulculator() { }
        public EquationCulculator(Func<double, double> function, double leftBorder, double rightBorder, double accuracy)
        {
            this.Function = function;
            this.LeftBorder = leftBorder;
            this.RightBorder = rightBorder;
            this.Accuracy = accuracy;
        }

        public Func<double, double> Function { get; set; }

        public double LeftBorder { get; set; }

        public double RightBorder { get; set; }

        public double Accuracy { get; set; }


        public CalculatorResult FindZero()
        {
            if(this.LeftBorder >= RightBorder)
            {
                return new CalculatorResult
                {
                    IsSuccessful = false,
                    ErrorMessage = "Invalid value of borders"
                };
            }

            double leftBorder = this.LeftBorder;
            double rightBorder = this.RightBorder;
            double desiredNumber = Math.Abs(rightBorder + leftBorder) / 2;

            while (Math.Abs(this.Function(desiredNumber)) > this.Accuracy)
            {
                if (Function(desiredNumber) * Function(leftBorder) < 0)
                {
                    rightBorder = desiredNumber;
                }
                else
                {
                    leftBorder = desiredNumber;
                }
                desiredNumber = (leftBorder + rightBorder) / 2;
            }

            return new CalculatorResult
            {
                Value = desiredNumber,
                IsSuccessful = true
            };
        }
    }
}