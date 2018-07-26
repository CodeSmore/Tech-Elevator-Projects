using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeChange
{
    class Program
    {
        /*
        Write a command line program which prompts the user for the total bill, and the amount tendered. It should then display the change required.
 
        C:\Users> MakeChange
         
        Please enter the amount of the bill: 23.65
        Please enter the amount tendered: 100.00
        The change required is 76.35
        */
        static void Main(string[] args)
        {
            decimal bill, tendered, change;

            Console.Write("Please enter the amount of the bill: ");
            bill = decimal.Parse(Console.ReadLine());

            Console.Write("Please enter the amount tendered: ");
            tendered = decimal.Parse(Console.ReadLine());

            change = tendered - bill;

            Console.WriteLine("The change required: " + change);
        }
    }
}
