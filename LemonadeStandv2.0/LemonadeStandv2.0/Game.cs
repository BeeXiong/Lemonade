using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Game
    {
        UserInterface gameInformation;
        List<Day> selectedGameDays;
        List<Player> gamePlayers;
        Store gameStore;
        Random rnd = new Random();
        public Game()
        {
            gameStore = new Store();
        }
        public void GameLoop()
        {
            gameInformation = new UserInterface();
            gameInformation.DisplayWelcome();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            gameInformation.DisplayRules();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            int userGameDaySelection;
            userGameDaySelection = SelectNumberOfGameDays();
            AddGameDays(userGameDaySelection); //bug weather all the same
            DisplayTotalGameDays();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            int numberOfPlayers = SelectNumberOfPlayers(); //bug takes input that is not an int
            CreatePlayers(numberOfPlayers);
            DisplayPlayers();
            string userSelectedGameLevel;
            userSelectedGameLevel = SelectGameLevel();
            SetBeginningPlayerBank(userSelectedGameLevel);
            DisplayPlayerWallet();
            while (gamePlayers.Count != 0)
            {
                foreach (Human gamePlayer in gamePlayers)
                {
                    Console.WriteLine("Okay, {0}.", gamePlayer.PlayerName);
                    gameInformation.DisplayOptions();
                    ReceiveOptionRequest(gameInformation, gamePlayer);
                }
            }
            Console.ReadKey();
        }
        public int SelectNumberOfGameDays()
        {
            Console.WriteLine("Please select the number of days you would like to play");
            int userinput;
            try
            {
                int.TryParse(Console.ReadLine(), out userinput);
                return userinput;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not a valid selection. Please try again.");
                SelectNumberOfGameDays();
            }
            return default(int);
        }
        public void AddGameDays(int userGameDays)
        {
            selectedGameDays = new List<Day>();
            int i;
            for (i = 0; i <= userGameDays; i++)
            {
                selectedGameDays.Add(new Day());
            }
        }
        public void DisplayTotalGameDays()
        {
            Console.WriteLine("Okay. We are playing for {0} days",selectedGameDays.Count-1);
        }
        public void DisplayGameOptions()
        {
            Console.WriteLine("Let's get started");
            Console.WriteLine("What would you like to do? 'Shop' - 'Make Lemonade' - ");
        }
        public int SelectNumberOfPlayers()
        {
            Console.WriteLine("Please select the number of players");
            int userinput;
            try
            {
                int.TryParse(Console.ReadLine(), out userinput);
                return userinput;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not a valid selection. Please try again.");
                SelectNumberOfGameDays();
            }
            return default(int);
        }
        public void CreatePlayers(int numberOfPlayers)
        {
            int i;
            gamePlayers = new List<Player>();
            for (i = 1; i <= numberOfPlayers; i++)
            {
                gamePlayers.Add(new Human());
            }
        }
        public void DisplayPlayers()
        {
            Console.WriteLine("Okay. Here's the list of players for this game");
            foreach (Human player in gamePlayers)
            {
                Console.WriteLine(player.PlayerName);
            }
        }
        public string SelectGameLevel()
        {
            Console.WriteLine("Please select game level. 'Easy' - 'Medium' - 'Hard' ");
            {
                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "easy":
                    case "medium":
                    case "hard":
                        return userInput;
                    default:
                        Console.WriteLine("Invaild Entry. Please select either 'Easy' - 'Medium' - 'Hard' ");
                        SelectGameLevel();
                        break;
                }
                return null;
            }
        }
        public void SetBeginningPlayerBank(string userInput)
        {
            string difficultyLevel = userInput;
            if (difficultyLevel == "easy")
            {
                Random rnd = new Random();
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = rnd.Next(30, 40);
                }
            }
            else if (difficultyLevel == "medium")
            {
                Random rnd = new Random();
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = rnd.Next(20, 30);
                }
            }
            else if (difficultyLevel == "hard")
            {
                Random rnd = new Random();
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = rnd.Next(10, 20);
                }
            }
        }
        public void DisplayPlayerWallet()
        {
            foreach (Human player in gamePlayers)
            {
                Console.WriteLine("{0} has {1} dollars in their wallet.",player.PlayerName, player.playerWallet.TotalDollars);
            }
        }
        public void ReceiveOptionRequest(UserInterface gameInfo,Human gamePlayer)
        {
            string userinput = Console.ReadLine().ToLower();
            switch (userinput)
            {
                case "rules":
                    gameInfo.DisplayRules();
                    gameInfo.RequestContinue();
                    gameInfo.DisplayOptions();
                    ReceiveOptionRequest(gameInfo, gamePlayer);
                    break;
                case "store":
                    ExecuteStoreOptions(gamePlayer);
                    break;
                case "kitchen":
                case "lemonade Sales":
                    break;
            }
        }
        private void ExecuteStoreOptions(Human gamePlayer)
        {
            string userSelectedItem;
            userSelectedItem = SelectItemToPurchase(gamePlayer);
            decimal purchaseQuantity;
            purchaseQuantity = SelectPurchaseAmount(userSelectedItem);
            decimal itemPrice;
            itemPrice = gameStore.DetermineItemPrice(userSelectedItem);
            decimal transactionAmount;
            transactionAmount = CalculatePrice(purchaseQuantity,itemPrice);
            bool customerConfirmation; 
            customerConfirmation = ConfirmPurchase();
            bool fundConfirmation;
            fundConfirmation = VerifyFundsForPurchase(transactionAmount, gamePlayer);
            gamePlayer.AddPurchaseItemToInventory(userSelectedItem, purchaseQuantity, customerConfirmation, fundConfirmation);
            bool shoppingResponse;
            shoppingResponse = PromptToContinueShopping();
            ContinueShopping(shoppingResponse,gamePlayer);
        }
        private string SelectItemToPurchase(Human gamePlayer)
        {
            Console.WriteLine("Okay {0}. What would you like to purchase?",gamePlayer.PlayerName);
            Console.WriteLine("Lemons");
            Console.WriteLine("Ice Cubes");
            Console.WriteLine("Sugar Cubes");
            Console.WriteLine("Cups");
            string userItemSelection = Console.ReadLine().ToLower();
            switch (userItemSelection)
            {
                case "lemons":
                case "ice cubes":
                case "sugar cubes":
                case "cups":
                    Console.WriteLine("You have choosen {0}", userItemSelection);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    SelectItemToPurchase(gamePlayer);
                    break;
            }
            return userItemSelection;
        }
        private decimal SelectPurchaseAmount(string userItemSelection)
        {
            Console.WriteLine("How many {0}s would you like", userItemSelection);
            string userInput = Console.ReadLine();
            decimal purchaseQuantity;
            decimal.TryParse(userInput, out purchaseQuantity);
            return purchaseQuantity;
        }
        private decimal CalculatePrice(decimal purchaseQuantity, decimal itemPrice)
        {
            decimal transactionPrice;
            transactionPrice = purchaseQuantity * itemPrice;
            Console.WriteLine("The total for this purchase will be {0}",transactionPrice);
            return transactionPrice;
        }
        private bool ConfirmPurchase()
        {
            Console.WriteLine("Would you like to purchase this item?");
            string userInput;
            userInput = Console.ReadLine().ToLower();
            if(userInput == "yes")
            {
                return true;
            }
            else if (userInput == "no")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid Entry. Please select 'Yes' or 'No'");
                ConfirmPurchase();
                return false;             
            }
        }
        private bool VerifyFundsForPurchase(decimal transactionAmount, Player gamePlayer)
        {
            if (transactionAmount <= gamePlayer.playerWallet.TotalDollars)
            {
                return true;
            }
            else if (transactionAmount > gamePlayer.playerWallet.TotalDollars)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        private bool PromptToContinueShopping()
        {
            Console.WriteLine("Would you like to continue shopping?");
            string userInput; 
            userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                return true;
            }
            else if (userInput != "yes" && userInput != "no")
            {
                Console.WriteLine("Invalid Selection. Please select either 'Yes' or 'No'");
                PromptToContinueShopping();
                return false;
            }
            else
            {
                return false;
            }
        }
        private void ContinueShopping(bool shoppingResponse,Human gamePlayer)
        {
            if (shoppingResponse == true)
            {
                ExecuteStoreOptions(gamePlayer);
            }
            else
            {
                Console.WriteLine("Alright {0}, Thanks for shopping!",gamePlayer.PlayerName);
            }
        }
        public void DisplayPlayerFunds()
        {

        }
    }
}
