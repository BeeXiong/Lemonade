using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SugarCubes
    {
        private double sugarCubePrice;
        public SugarCubes()
        {

        }
        public void SetPrice()
        {
            sugarCubePrice = .01;
            Console.WriteLine(sugarCubePrice);
        }
        public double GetPrice()
        {
            return sugarCubePrice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}
