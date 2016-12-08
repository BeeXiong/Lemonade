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
        public Recipe gameRecipe;
        string inventoryItem;
        decimal inventoryAmount;

        public HumanPlayer()
        {
            playerWallet = new Wallet();
            gameInventory = new Inventory();
            gameRecipe = new Recipe();
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
                gameInventory.gameSugarCubes.Add(gameInventory.newSugarCube = new SugarCubes());
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
        public void SetDailyLemonadeCupInventory()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("Lets make some Lemonade!");
            Console.WriteLine("How many cups would you like to make?");
            string userInput = Console.ReadLine();
            decimal.TryParse(userInput, out inventoryAmount);
        }
        public void VeryifyCupAmount()
        {
            if (gameInventory.GetCupQuantity() < GetInventoryAmount())
            {
                Console.WriteLine("I'm sorry. You didn't have enough cups");
                SetDailyLemonadeCupInventory();
            }
        }
        public void SetLemonCupTaste()
        {
            gameRecipe.ChooseIngredients();
            gameRecipe.VeryifyLemonAmount((gameInventory.GetLemonQuantity()));
            gameRecipe.VeryifyIceCubeAmount((gameInventory.GetIceCubeQuantity()));
            gameRecipe.VeryifySugarAmount((gameInventory.GetSugarCubeQuantity()));
            VeryifyCupAmount();
        }
        public void MakeLemonadeCups()
        {
            for (int index = 1; index <= GetInventoryAmount(); index++)
            {
                if (gameRecipe.GetSourTaste() == true)
                {
                    gameInventory.sourLemonadeCups.Add(gameInventory.newSourLemonadeCup = new LemonadeCup());
                }
                if (gameRecipe.GetSweetTaste() == true)
                {
                    gameInventory.SweetLemonadeCups.Add(gameInventory.newSweetLemonadeCup = new LemonadeCup());
                }
                if (gameRecipe.GetNuetralTaste() == true)
                {
                    gameInventory.NuetralLemonadeCups.Add(gameInventory.newNuetralLemonadeCup = new LemonadeCup());
                }
            }
        }
                    public void SubtractInventory()//exemption??
        {
            string itemSelection = gameRecipe.GetItemSelection();
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
            }
        }
    }
}
