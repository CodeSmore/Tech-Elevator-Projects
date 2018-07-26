using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostageCalculator.Classes
{
    class PostalServiceSecondClass : IDeliveryDriver
    {
        int Weight { get; }
        int Miles { get; }

        public double CalculateRate(int Distance, double Weight)
        {
            decimal rate = 0.0000M;

            if (Weight >= 0 && Weight <= 2)
            {
                rate = Distance * 0.0035M;
            }
            else if (Weight >= 3 && Weight <= 8)
            {
                rate = Distance * 0.0040M;
            }
            else if (Weight >= 9 && Weight <= 15)
            {
                rate = Distance * 0.0047M;
            }
            else if ((Weight >= 1 * 16) && (Weight <= 3 * 16))
            {
                rate = Distance * 0.0195M;
            }
            else if ((Weight >= 4 * 16) && (Weight <= 8 * 16))
            {
                rate = Distance * 0.0450M;
            }
            else if (Weight >= 9 * 16)
            {
                rate = Distance * 0.0500M;
            }

            return (double)rate;
        }
    }
}
