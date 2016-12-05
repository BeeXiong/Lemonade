using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Program
    {
        static void Main(string[] args)
        {
            Store Test = new Store();
            Test.IdentifyItem();
            Test.DefineItemAmount();
            Test.PurchaseItem();
         

            Console.ReadKey();
        }
    }
}
