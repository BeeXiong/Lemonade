using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class IceCube
    {
        private double iceCubePrice;
        public IceCube()
        {
    
        }
        public void SetPrice()
        {
            iceCubePrice = .01;
            Console.WriteLine(iceCubePrice);
        }
        public double GetPrice()
        {
            return iceCubePrice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}
