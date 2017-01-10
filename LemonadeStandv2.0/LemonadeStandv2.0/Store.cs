using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Store
    {
        public Store()
        {
        }
        public decimal DetermineItemPrice(string userSelectedItem)
        {
            decimal itemPrice;
            if (userSelectedItem == "lemons")
            {
                itemPrice = Lemon.Price;
                return itemPrice;
            }
            else if (userSelectedItem == "ice cubes")
            {
                itemPrice = IceCube.Price;
                return itemPrice;
            }
            else if (userSelectedItem == "sugar cubes")
            {
                itemPrice = SugarCube.Price;
                return itemPrice;
            }
            else if (userSelectedItem == "cups")
            {
                itemPrice = Cup.Price;
                return itemPrice;
            }
            else
            {
                return default(decimal);
            } 
        }
    }
}
