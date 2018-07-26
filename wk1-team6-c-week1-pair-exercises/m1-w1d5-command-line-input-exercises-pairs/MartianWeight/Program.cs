using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianWeight
{
    class Program
    {
        /*
        In case you've ever pondered how much you weight on Mars, here's the calculation:
 	    Wm = We* 0.378
 	    where 'Wm' is the weight on Mars, and 'We' is the weight on Earth

        Write a command line program which accepts a series of Earth weights from the user  
        and displays each Earth weight as itself, and its Martian equivalent.


        C:\Users> MartianWeight  
        Enter a series of Earth weights (space-separated): 98 235 185
        String.Split()
            
        98 lbs.on Earth, is 37 lbs.on Mars.
        235 lbs.on Earth, is 88 lbs.on Mars.
        185 lbs.on Earth, is 69 lbs.on Mars. 
        */
        static void Main(string[] args)
        {
            double[] weights;
            string[] placeHolder;

            Console.Write("Enter a series of Earth weights (space-separated): ");
            string userInput = Console.ReadLine();

            placeHolder = userInput.Split();

            weights = new double[placeHolder.Length];

            for (int i = 0; i < placeHolder.Length; ++i)
            {
                weights[i] = double.Parse(placeHolder[i]);
            }

            for (int i = 0; i < placeHolder.Length; ++i)
            {
                Console.WriteLine(weights[i] + "lbs. on Earth, is " + ConvertEtoM(weights[i]) +"lbs. on Mars.");
            }



        }

        static double ConvertEtoM(double earthWeight)
        {
            double marsWeight;

            marsWeight = earthWeight * 0.378D;

            return marsWeight;
        }
    }
}
