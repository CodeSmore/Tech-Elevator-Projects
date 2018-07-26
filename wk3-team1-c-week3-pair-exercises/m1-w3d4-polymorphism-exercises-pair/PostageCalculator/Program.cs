using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostageCalculator.Classes;

namespace PostageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int weight = 0;
            int distance = 0;
            string weightType = "";
            Console.WriteLine("Please enter the weight of the package: ");
            weight = int.Parse(Console.ReadLine());
            Console.WriteLine("(P)ounds or (O)unces: ");
            weightType = Console.ReadLine();
            weight = CheckWeightType(weightType, weight);
            Console.WriteLine("What distance will it be travelling to: ");
            distance = int.Parse(Console.ReadLine());


            List<IDeliveryDriver> listOfRates = new List<IDeliveryDriver>
            {
                new PostalServiceFirstClass(),
                new PostalServiceSecondClass(),
                new PostalServiceThirdClass(),
                new FedEx(),
                new SPUFourDayGround(),
                new SPUTwoDayBusiness(),
                new SPUNextDay()
            };

            List<double> listOfDoubleRates = new List<double>(); 

            foreach(IDeliveryDriver deliveryDriver in listOfRates)
            {
                listOfDoubleRates.Add(deliveryDriver.CalculateRate(distance, weight));
            }

            outputTable(listOfDoubleRates);
        }
        
        public static int CheckWeightType(string weightType, int weight)
        {
            if(weightType == "P")
            {
                weight *= 16;
            }
            return weight;
        }

        public static void outputTable(List<double> listOfDoubleRates)
        {
            Console.WriteLine("Delivery Method                   $ cost");
            Console.WriteLine("----------------------------------------");
            Console.Write("Postal Service(First Class):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[0]).PadLeft(12));
            Console.Write("Postal Service(Second Class):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[1]).PadLeft(11));
            Console.Write("Postal Service(Third Class):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[2]).PadLeft(12));
            Console.Write("FexEd:");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[3]).PadLeft(34));
            Console.Write("SPU (4-Day Ground):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[4]).PadLeft(21));
            Console.Write("SPU (2-Day Business):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[5]).PadLeft(19));
            Console.Write("SPU (Next-Day):");
            Console.WriteLine(String.Format("{0:C}", listOfDoubleRates[6]).PadLeft(25));
            Console.ReadLine();
        }
    }
}
