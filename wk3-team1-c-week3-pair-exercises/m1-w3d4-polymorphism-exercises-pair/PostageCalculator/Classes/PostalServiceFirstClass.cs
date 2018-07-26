using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostageCalculator.Classes
{
    class PostalServiceFirstClass : IDeliveryDriver
    {
        int Weight { get; }
        int Miles { get; }

        public double CalculateRate(int Distance, double Weight)
        {
            double rate = 0.000;

            if (Weight >= 0 && Weight <= 2)
            {
                rate = Distance * 0.035;
            }
            else if (Weight >= 3 && Weight <= 8)
            {
                rate = Distance * 0.040;
            }
            else if (Weight >= 9 && Weight <= 15)
            {
                rate = Distance * 0.047;
            }
            else if ((Weight >= 1 * 16) && (Weight <= 3*16))
            {
                rate = Distance * 0.195;
            }
            else if ((Weight >= 4 * 16) && (Weight <= 8 * 16))
            {
                rate = Distance * 0.45;
            }
            else if(Weight >= 9 * 16)
            {
                rate = Distance * 0.5;
            }

            return rate;
        }
    }
}
