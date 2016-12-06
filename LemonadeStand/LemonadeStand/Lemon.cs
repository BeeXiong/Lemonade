using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Lemon
    {
        public double lemonprice;
        public Lemon()
        {
            
        }
        public void SetPrice()
        {
            lemonprice = .25;
            
        }
        public double GetPrice()
        {
            return lemonprice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}