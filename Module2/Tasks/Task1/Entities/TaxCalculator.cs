using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Entities
{
    public class TaxCalculator
    {
        private int _companyCount;
        private double _profit;
        private double _taxPercentage;

        public TaxCalculator(IInitializer initializer)
        {
            if(initializer == null)
            {
                throw new NullReferenceException(nameof(initializer));
            }

            this._companyCount  = initializer.GetCompanyCount();
            this._profit        = initializer.GetProfit();
            this._taxPercentage = initializer.GetTaxPercentage();
        }

        public double CalculateTotalTax()
        {
            return this._companyCount * this._profit * this._taxPercentage / 100;
        }
    }
}
