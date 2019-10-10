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
        private IInitializer _initializer;

        public TaxCalculator(IInitializer initializer)
        {
            this._initializer = initializer ?? throw new NullReferenceException(nameof(initializer));
        }


    }
}
