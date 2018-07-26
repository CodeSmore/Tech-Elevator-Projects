using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostageCalculator.Classes
{
    class PostalServiceThirdClass : IDeliveryDriver
    {
        public double CalculateRate(int Distance, double Weight)
        {
            double rate = 0.000;

            if (Weight >= 0 && Weight <= 2)
            {
                rate = Distance * 0.002;
            }
            else if (Weight >= 3 && Weight <= 8)
            {
                rate = Distance * 0.0022;
            }
            else if (Weight >= 9 && Weight <= 15)
            {
                rate = Distance * 0.0024;
            }
            else if ((Weight >= 1 * 16) && (Weight <= 3 * 16))
            {
                rate = Distance * 0.0150;
            }
            else if ((Weight >= 4 * 16) && (Weight <= 8 * 16))
            {
                rate = Distance * 0.0160;
            }
            else if (Weight >= 9 * 16)
            {
                rate = Distance * 0.0170;
            }

            return rate;
        }
    }
}
