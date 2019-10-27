using System;
using Module.Helper.Results;

namespace Task8
{
    public class EquationCalculator
    {
        public EquationCalculator() { }
        public EquationCalculator(Func<double, double> function, double leftBorder, double rightBorder, double accuracy)
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


        public CountingResult<double> FindZero()
        {
            if (this.LeftBorder >= RightBorder)
            {
                GetErrorResult<double>("Invalid value of borders");
            }

            return new CountingResult<double>
            {
                Params = GetZeroOfCurrentFunc(this.LeftBorder, this.RightBorder),
                IsSuccessful = true
            };
        }

        private double GetZeroOfCurrentFunc(double leftBorder, double rightBorder)
        {
            var desiredNumber = Math.Abs(rightBorder + leftBorder) / 2;
            
            if (Function(desiredNumber) * Function(leftBorder) < 0)
            {
                rightBorder = desiredNumber;
            }
            else
            {
                leftBorder = desiredNumber;
            }

            return Math.Abs(this.Function(desiredNumber)) > this.Accuracy ? 
                GetZeroOfCurrentFunc(leftBorder, rightBorder) : 
                desiredNumber;
        }

        private CountingResult<T> GetErrorResult<T>(string errorMessage)
        {
            return new CountingResult<T>
            {
                IsSuccessful = false,
                ErrorMessage = errorMessage
            };
        }
    }
}
