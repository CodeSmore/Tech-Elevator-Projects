using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostageCalculator.Classes
{
    class SPUNextDay : IDeliveryDriver
    {
        public double CalculateRate(int weight, double distance)
        {
            return (((double)weight / 16) * 0.075) * distance;
        }
    }
}
