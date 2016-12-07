using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    
    class Wallet
    {
        private string selectedItem;
        protected decimal playerBank;
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
        public void SetItemSelection(string userInput)
        {
            selectedItem = userInput;
        }
        public string GetItemSelection()
        {
            return selectedItem;
        }
        public decimal GetPlayerBank()
        {
            return playerBank;
        }
        public void SetBeginningPlayerBank()
        {
            string difficultyLevel = GetItemSelection();
            if (difficultyLevel == "easy")
            {
                Random rnd = new Random();
                playerBank = rnd.Next(30, 40);
            }
            else if (difficultyLevel == "medium")
            {
                Random rnd = new Random();
                playerBank = rnd.Next(20, 30);
            }
            else if (difficultyLevel == "hard")
            {
                Random rnd = new Random();
                playerBank = rnd.Next(10, 20);
            }
        }
        public void SetPlayerBank(decimal NewAmount)
        {
            playerBank = NewAmount;
        }
        public void DisplayPlayerBank()
        {
            Console.WriteLine(GetPlayerBank());
        }
    }

}

