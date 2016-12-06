using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class IceCube
    {
        private decimal iceCubePrice;
        public IceCube()
        {
    
        }
        public void SetPrice()
        {
            iceCubePrice = .01m;
            Console.WriteLine(iceCubePrice);
        }
        public decimal GetPrice()
        {
            return iceCubePrice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}
