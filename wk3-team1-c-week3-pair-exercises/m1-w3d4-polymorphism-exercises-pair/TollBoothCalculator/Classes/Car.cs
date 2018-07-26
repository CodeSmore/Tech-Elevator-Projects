using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollBoothCalculator.Classes
{
    public class Car : IVehicle
    {
        public bool HasTrailer { get; }

        public double CalculateToll(int distance)
        {
            double toll = distance * 0.020;

            if (HasTrailer)
            {
                toll += 1.00;
            }
            return toll;
        }

        public Car(bool hasTrailer)
        {
            HasTrailer = hasTrailer;
        }
    }
}
