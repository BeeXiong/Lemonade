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
            Lemon Testing = new Lemon();
            Cup Tests = new Cup();
            SugarCubes Testtest = new SugarCubes();
            IceCube TestingTest = new IceCube();
            Inventory Tester = new Inventory();
           


            Test.IdentifyItem();
            Test.SetItemAmount();
            Tester.AddInventory(Test);


            Test.SetTransactionAmount(Testing,TestingTest,Tests,Testtest);
            

            
        

         

            Console.ReadKey();
        }
    }
}
