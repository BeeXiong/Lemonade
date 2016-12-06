using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class SugarCubes
    {
        private decimal sugarCubePrice;
        public SugarCubes()
        {

        }
        public void SetPrice()
        {
            sugarCubePrice = .01m;
            Console.WriteLine(sugarCubePrice);
        }
        public decimal GetPrice()
        {
            return sugarCubePrice;
        }
        public void find()
        {
            Console.WriteLine(GetPrice());
        }
    }
}
