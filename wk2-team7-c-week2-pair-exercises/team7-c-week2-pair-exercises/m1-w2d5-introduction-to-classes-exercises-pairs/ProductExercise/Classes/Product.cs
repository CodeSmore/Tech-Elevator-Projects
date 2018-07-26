using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    public class Product
    {
        private string name;
        private decimal price;
        private double weightInOunces;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
            }
        }

        public double WeightInOunces
        {
            get
            {
                return weightInOunces;
            }
            set
            {
                weightInOunces = value;
            }
        }
    }
}
