using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class LemonadeCup
    {
        public decimal Price { get; private set; }
        public string Taste { get; private set; }
        public LemonadeCup(decimal Price, string Taste)//allows you to construct a lemonade cup with a different price
        {
            this.Price = Price;
            this.Taste = Taste;
        }
    }
}
