using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon
    {
        public decimal lemonprice;
        public Lemon()
        {
            
        }
        public void SetPrice()
        {
            lemonprice = .25m;   
        }
        public decimal GetPrice()
        {
            return lemonprice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}