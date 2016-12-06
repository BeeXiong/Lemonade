using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        List<Lemon> gameLemons;
        List<Cup> gameCups;
        List<SugarCubes> gameSugar;
        List<IceCube> gameIceCubes;

        public Inventory()
        {
            gameLemons = new List<Lemon>();
            gameCups = new List<Cup>();
            gameSugar = new List<SugarCubes>();
            gameIceCubes = new List<IceCube>();
        }
        public void SubtractInventory(Store storePurchase)//exemption??
        {
            for (int index = 1; index <= storePurchase.getPurchaseAmount(); index++ ) 
            {
                if (storePurchase.getPurchaseItem() == "lemons")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (storePurchase.getPurchaseItem() == "ice cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (storePurchase.getPurchaseItem() == "sugar cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (storePurchase.getPurchaseItem() == "cups")
                {
                    gameLemons.RemoveAt(0);
                }


                //merge list and for each the data type into a new list to compare agianst
            }
        }
        public void AddInventory(Store storePurchase)
        {
            for (int index = 1; index <= storePurchase.getPurchaseAmount(); index++)
            {
                if (storePurchase.getPurchaseItem() == "lemons")
                {
                    gameLemons.Add(new Lemon());
                }
                else if (storePurchase.getPurchaseItem() == "ice cubes")
                {
                    gameIceCubes.Add(new IceCube());
                }
                else if (storePurchase.getPurchaseItem() == "sugar cubes")
                {
                    gameSugar.Add(new SugarCubes());
                }
                else if (storePurchase.getPurchaseItem() == "cups")
                {
                    gameCups.Add(new Cup());
                }
            }
        }
        public void DisplayInventory()
        {
            Console.WriteLine("game lemons {0}",gameLemons.Count);
            Console.WriteLine("game Ice Cubes {0}", gameIceCubes.Count);
            Console.WriteLine("game Sugar {0}", gameSugar.Count);
            Console.WriteLine("game cups {0}", gameCups.Count);
        }

    }
}
