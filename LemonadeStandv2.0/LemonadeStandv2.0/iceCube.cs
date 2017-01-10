using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class IceCube
    {
        static decimal price = .01m;
        public static decimal Price
        {
            get
            {
                return price;
            }
            private set
            {
                price = value;
            }
        }
        public IceCube()
        {
            Price = .01m;
        }
    }
}
