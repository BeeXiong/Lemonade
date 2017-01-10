using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Lemon
    {
        static decimal price = .10m;
        public static decimal Price
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
        public Lemon()
        {
            
        }
    }
}
