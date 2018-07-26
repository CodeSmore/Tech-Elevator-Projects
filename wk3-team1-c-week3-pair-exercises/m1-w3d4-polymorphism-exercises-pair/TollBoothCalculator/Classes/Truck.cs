using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TollBoothCalculator.Classes
{
    public class Truck : IVehicle
    {
        int NumberOfAxles { get; }

        public Truck(int numberOfAxles)
        {
            NumberOfAxles = numberOfAxles;
        }

        public double CalculateToll(int distance)
        {
            double toll = 0;

            if (NumberOfAxles == 4)
            {
                toll = distance * .040;
            }
            else if (NumberOfAxles == 6)
            {
                toll = distance * .045;
            }
            else if (NumberOfAxles >= 8)
            {
                toll = distance * .048;
            }

            return toll;
        }

       
    }
}
