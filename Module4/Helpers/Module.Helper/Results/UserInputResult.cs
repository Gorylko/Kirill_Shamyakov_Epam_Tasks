using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module.Helper.Results
{
    public class UserInputResult<TValue>
    {
        public TValue Value { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
