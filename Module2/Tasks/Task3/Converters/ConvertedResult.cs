using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Converters
{
    public class ConvertedResult<TResult>
    {
        public TResult Value { get; set; }

        public bool IsSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
