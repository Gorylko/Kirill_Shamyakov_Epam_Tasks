using System;
using Task1.DataInitializers.Params;

namespace Task1.Calculators
{
    public class TaxCalculator
    {
        public TaxCalculatorParams Params { get; set; }

        public TaxCalculator(TaxCalculatorParams @params)
        {
            this.Params = @params ?? throw new NullReferenceException(nameof(@params));
        }

        public double CalculateTotalTax()
        {
            return this.Params.CompanyCount * this.Params.Profit * this.Params.TaxPercentage / 100;
        }
    }
}
