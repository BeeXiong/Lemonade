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
        public Lemon newLemon;
        public Cup newCup;
        public SugarCubes newSugarCube;
        public IceCube newIceCube;
        string inventoryItem;
        decimal inventoryAmount;
        

        public Inventory()
        {
            gameLemons = new List<Lemon>();
            gameCups = new List<Cup>();
            gameSugar = new List<SugarCubes>();
            gameIceCubes = new List<IceCube>();
        }
        public void IdentifyInventoryItem()//need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("What would you like?");
            Console.WriteLine("Lemons");
            Console.WriteLine("Ice Cubes");
            Console.WriteLine("Sugar Cubes");
            Console.WriteLine("Cups");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "lemons":
                case "ice cubes":
                case "sugar cubes":
                case "cups":
                    SetInventoryItemSelection(userInput);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    IdentifyInventoryItem();
                    break;
            }
        }
        public void SetInventoryItemSelection(string userInput)
        {
            inventoryItem = userInput;
        }
        public string GetInventoryItemSelection()
        {
            return inventoryItem;
        }
        public void IdentifyInventoryAmount()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("You have selected {0}", GetInventoryItemSelection());
            Console.WriteLine("How many {0} would you like", GetInventoryItemSelection());
            string userInput = Console.ReadLine();
            decimal.TryParse(userInput, out inventoryAmount);
        }
        public decimal GetInventoryAmount()
        {
            return inventoryAmount;
        }
        public void SubtractInventory()//exemption??
        {
            string itemSelection = GetInventoryItemSelection();
            for (int index = 1; index <= GetInventoryAmount(); index++) 
            {
                if (itemSelection == "lemons")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "ice cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "sugar cubes")
                {
                    gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "cups")
                {
                    gameLemons.RemoveAt(0);
                }
                //merge list and for each the data type into a new list to compare agianst
            }
        }
        public void AddInventory()
        {
            string itemSelection = GetInventoryItemSelection();
            for (int index = 1; index <= GetInventoryAmount(); index++)
            {
                if (itemSelection == "lemons")
                {
                    gameLemons.Add(newLemon = new Lemon());
                }
                else if (itemSelection == "ice cubes")
                {
                    gameIceCubes.Add(newIceCube = new IceCube());
                }
                else if (itemSelection == "sugar cubes")
                {
                    gameSugar.Add(newSugarCube = new SugarCubes());
                }
                else if (itemSelection == "cups")
                {
                    gameCups.Add(newCup = new Cup());
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
