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
        private bool _isSuccessful;

        public ConsoleInitializer()
        {
            this._profit = 500;
        }

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

        public void Initialize() // Need more if's !!!
        {
            this._isSuccessful = true;
            int companyCount;
            double tax;

            Console.WriteLine("Enter the number of companies");
            if (!int.TryParse(Console.ReadLine(), out companyCount) &&
                companyCount < 0)
            {
                BugReport(nameof(this._companyCount));
            }

            Console.WriteLine("Enter tax percentage");
            if(!double.TryParse(Console.ReadLine(), out tax) &&
                tax < 0 &&
                tax > 100)
            {
                BugReport(nameof(this._taxPercentage));
            }

            if (this._isSuccessful)
            {
                this._companyCount  = companyCount;
                this._taxPercentage = tax;
            }

            //Console.WriteLine("");
            //if(!double.TryParse(Console.ReadLine(), out this._profit)) { }  %% By condition %%
        }

        public bool IsSuccessful()
        {
            return this._isSuccessful;
        }

        private void BugReport(string culprit)
        {
            Console.WriteLine(culprit + " caused application error");
            this._isSuccessful = false;
        }
    }
}
