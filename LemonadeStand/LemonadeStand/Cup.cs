using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Cup
    {
        private double cupPrice;
        public Cup()
        {

        }
        public void SetPrice()
        {
            cupPrice = .10;
            Console.WriteLine(cupPrice);
        }
        public double GetPrice()
        {
            return cupPrice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }


    }
}
