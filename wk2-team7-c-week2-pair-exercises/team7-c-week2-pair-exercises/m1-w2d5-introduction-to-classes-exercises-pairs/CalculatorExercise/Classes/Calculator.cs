using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// Represents a "simple" calculator
    /// </summary>
    public class Calculator
    {
        private int result;

        public int Result
        {
            get
            {
                return result;
            }
            private set
            {
                result = value;
            }
        }

        public Calculator(int startingResult)
        {
            result = startingResult;
        }

        public int Add(int addend)
        {
            result += addend;

            return result;
        }

        public int Subtract(int subtrahend)
        {
            result -= subtrahend;

            return result;
        }

        public int Multiply(int multiplier)
        {
            result *= multiplier;

            return result;
        }

        public int Power(int exponent)
        {
            result = (int)Math.Pow(result, exponent);

            return result;
        }

        public void Reset()
        {
            result = 0;
        }

    }
}
