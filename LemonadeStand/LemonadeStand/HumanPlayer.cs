using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class HumanPlayer : Player
    {
        public Wallet playerWallet;
        public Inventory gameInventory;
        string inventoryItem;
        decimal inventoryAmount;

        public HumanPlayer()
        {
            playerWallet = new Wallet();
            gameInventory = new Inventory();

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
                    gameInventory.gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "ice cubes")
                {
                    gameInventory.gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "sugar cubes")
                {
                    gameInventory.gameLemons.RemoveAt(0);
                }
                else if (itemSelection == "cups")
                {
                    gameInventory.gameLemons.RemoveAt(0);
                }
                //merge list and for each the data type into a new list to compare agianst
            }
        }
        public void AddLemonInventory(decimal Lemons)
        {
            for (int index = 1; index <= Lemons; index++)
            {
                gameInventory.gameLemons.Add(gameInventory.newLemon = new Lemon());
              
            }
        }
        public void AddIceCubeInventory(decimal iceCubes)
        {
            for (int index = 1; index <= iceCubes; index++)
            {
                gameInventory.gameIceCubes.Add(gameInventory.newIceCube = new IceCube());

            }
        }
        public void AddSugarCubeInventory(decimal sugarCube)
        {
            for (int index = 1; index <= sugarCube; index++)
            {
                gameInventory.gameSugar.Add(gameInventory.newSugarCube = new SugarCubes());

            }
        }
        public void AddCupInventory(decimal cups)
        {
            for (int index = 1; index <= cups; index++)
            {
                gameInventory.gameCups.Add(gameInventory.newCup = new Cup());

            }
        }

        public override void NamePlayers()
        {
            base.NamePlayers();
        }

        
    }
}
