using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Interfaces;

namespace Task1.Entities
{
    public class ConsoleInitializer : IInitializer
    {
        private int _companyCount;
        private double _profit;
        private double _taxPercentage;

        public int GetCompanyCount()
        {
            return this._companyCount;
        }

        public double GetProfit()
        {
            return this._profit;
        }

        public double GetTaxPercentage()
        {
            return this._taxPercentage;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }
    }
}
