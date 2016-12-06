using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Cup
    {
        private decimal cupPrice;
        public Cup()
        {

        }
        public void SetPrice()
        {
            cupPrice = .10m;
            //Console.WriteLine(cupPrice);
        }
        public decimal GetPrice()
        {
            return cupPrice;
        }
        //public void find()
        //{
        //    Console.WriteLine(GetPrice());
        //}
    }
}
