using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4.DataInitializers
{
    public class UserInputResult<TParam>
    {
        public TParam Param { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
