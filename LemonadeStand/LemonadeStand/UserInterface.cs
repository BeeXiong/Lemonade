using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class UserInterface
    {
        private string selectedItem;
        private int selectedAmount;
        
        public void DisplayWelcome()
        {

        }
        public void DisplayRules()
        {

        }
        public void SelectGameLevel()
        {
            Console.WriteLine("Please select game level. 'Easy' - 'Medium' - 'Hard' ");
            {
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "easy":
                    case "medium":
                    case "Hard":
                        SetItemSelection(userInput);
                        break;
                    default:
                        Console.WriteLine("Invaild Entry. Please select either 'Easy' - 'Medium' - 'Hard' ");
                        SelectGameLevel();
                        break;
                }
            }
        }
        public void DisplayOptions()
        {
            Console.WriteLine("What would you like to access? Please choose from one of the following: ");
            Console.WriteLine("Rules");
            Console.WriteLine("Store");
            Console.WriteLine("Kitchen");
            Console.WriteLine("Lemonade Sales");
            string userinput = Console.ReadLine().ToLower();
            switch (userinput)
            {
                case "Rules":
                    DisplayRules();
                    break;
                case "Store":

                case "Kitchen":
                case "Lemonade Sales":
                    break;
            }
        }
        public void IdentifyItem()//need a exemption handle for the amount of items a user picks
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
                    SetItemSelection(userInput);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    IdentifyItem();
                    break;
            }
        }
        public void SetItemSelection(string userInput)
        {
            selectedItem = userInput;
        }
        public string GetItemSelection()
        {
            return selectedItem;
        }
        public void IdentifyItemAmount()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("You have selected {0}", GetItemSelection());
            Console.WriteLine("How many {0} would you like", GetItemSelection());
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out selectedAmount);
        }
        public decimal GetPurchaseAmount()
        {
            return selectedAmount;
        }

        public void RestartGame()
        {

        }
        public void SelectPlayers()
        {

        }
    }
}
