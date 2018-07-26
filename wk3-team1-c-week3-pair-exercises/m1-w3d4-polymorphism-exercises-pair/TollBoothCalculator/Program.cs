using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TollBoothCalculator.Classes;

namespace TollBoothCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IVehicle> listOfVehicles = new List<IVehicle>();

            listOfVehicles.Add(new Car(true));
            listOfVehicles.Add(new Car(false));
            listOfVehicles.Add(new Truck(6));
            listOfVehicles.Add(new Truck(8));
            listOfVehicles.Add(new Tank());

            foreach (IVehicle vehicle in listOfVehicles)
            {
                Console.WriteLine("Toll: " + vehicle.CalculateToll(100));
            }
            Console.ReadLine();
            
        }
    }
}
