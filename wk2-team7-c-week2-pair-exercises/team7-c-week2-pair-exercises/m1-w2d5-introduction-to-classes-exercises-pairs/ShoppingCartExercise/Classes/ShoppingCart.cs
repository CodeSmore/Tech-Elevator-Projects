using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// A shopping cart class stores items in it.
    /// </summary>
    public class ShoppingCart
    {
        private int totalNumberOfItems;
        private decimal totalAmountOwed;

        public ShoppingCart()
        {
            totalNumberOfItems = 0;
            totalAmountOwed = 0.00M;
        }

        public int TotalNumberOfItems
        {
            get
            {
                return totalNumberOfItems;
            }
            private set
            {
                totalNumberOfItems = value;
            }

        }
        public decimal TotalAmountOwed
        {
            get
            {
                return totalAmountOwed;
            }
            private set
            {
                totalAmountOwed = value;
            }
        }

        public decimal GetAveragePricePerItem()
        {
            if (TotalNumberOfItems != 0) {
                return TotalAmountOwed / TotalNumberOfItems;
            }

            return 0;
        }
        public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            totalNumberOfItems = numberOfItems;
            totalAmountOwed = pricePerItem * numberOfItems;
        }

        public void Empty()
        {
            totalNumberOfItems = 0;
            totalAmountOwed = 0.00M;
        }

    }
}
