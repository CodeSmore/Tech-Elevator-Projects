using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostageCalculator.Classes
{
    class SPUFourDayGround : IDeliveryDriver
    {
        public double CalculateRate(int weight, double distance)
        {

            return (((double)weight/16) * 0.0050) * distance;
        }
    }
}
