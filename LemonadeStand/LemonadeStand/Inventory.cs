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
        UserInterface userEntry;
        Lemon newLemon;
        Cup newCup;
        SugarCubes newSugarCube;
        IceCube newIceCube;

        public Inventory(UserInterface userEntry)
        {
            gameLemons = new List<Lemon>();
            gameCups = new List<Cup>();
            gameSugar = new List<SugarCubes>();
            gameIceCubes = new List<IceCube>();
            this.userEntry = userEntry;
        }

        public Inventory()
        {
        }

        public void SubtractInventory()//exemption??
        {
            for (int index = 1; index <= userEntry.GetPurchaseAmount(); index++ ) 
            {
                if (userEntry.GetItemSelection() == "lemons")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (userEntry.GetItemSelection() == "ice cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (userEntry.GetItemSelection() == "sugar cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (userEntry.GetItemSelection() == "cups")
                {
                    gameLemons.RemoveAt(0);
                }
                //merge list and for each the data type into a new list to compare agianst
            }
        }
        public void AddInventory()
        {
            for (int index = 1; index <= userEntry.GetPurchaseAmount(); index++)
            {
                if (userEntry.GetItemSelection() == "lemons")
                {
                    gameLemons.Add(new Lemon());
                }
                else if (userEntry.GetItemSelection() == "ice cubes")
                {
                    gameIceCubes.Add(new IceCube());
                }
                else if (userEntry.GetItemSelection() == "sugar cubes")
                {
                    gameSugar.Add(new SugarCubes());
                }
                else if (userEntry.GetItemSelection() == "cups")
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
