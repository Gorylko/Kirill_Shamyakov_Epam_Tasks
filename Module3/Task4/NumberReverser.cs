using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class NumberReverser
    {
        private bool _isNegative;

        public void Reverse(ref int number)
        {
            if(number == 0)
            {
                return;
            }

            if (number < 0)
            {
                _isNegative = true;
                number *= -1;
            }

            number = this._isNegative ? - int.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()))
                : int.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
            _isNegative = false;
        }

        public void Reverse(ref double number)
        {
            if (number == 0)
            {
                return;
            }

            if (number < 0)
            {
                _isNegative = true;
                number *= -1;
            }

            number = this._isNegative? - double.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()))
                : double.Parse(new string(number.ToString().ToCharArray().Reverse().ToArray()));
            _isNegative = false;
        }
    }
}
