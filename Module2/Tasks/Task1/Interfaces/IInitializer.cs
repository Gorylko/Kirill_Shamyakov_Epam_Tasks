using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Interfaces
{
    public interface IInitializer
    {
        void Initialize();

        int GetCompanyCount();

        double GetTaxPercentage();

        double GetProfit();
    }
}
