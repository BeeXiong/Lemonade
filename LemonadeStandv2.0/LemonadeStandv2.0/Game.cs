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
        Random rndNumber;
        public Game()
        {
            gameStore = new Store();
            rndNumber = new Random();
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
            AddGameDays(userGameDaySelection, rndNumber); //bug weather all the same
            DisplayTotalGameDays();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            int numberOfPlayers = SelectNumberOfPlayers(); //bug takes input that is not an int
            CreatePlayers(numberOfPlayers);
            DisplayPlayers();
            string userSelectedGameLevel;
            userSelectedGameLevel = SelectGameLevel();
            SetBeginningPlayerBank(userSelectedGameLevel,rndNumber);
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
        public void AddGameDays(int userGameDays, Random randomNumber)
        {
            selectedGameDays = new List<Day>();
            int i;
            for (i = 0; i <= userGameDays; i++)
            {
                selectedGameDays.Add(new Day(randomNumber));
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
        public void SetBeginningPlayerBank(string userInput, Random randomNumber)
        {
            string difficultyLevel = userInput;
            if (difficultyLevel == "easy")
            {
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = randomNumber.Next(30, 40);
                }
            }
            else if (difficultyLevel == "medium")
            {
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = randomNumber.Next(20, 30);
                }
            }
            else if (difficultyLevel == "hard")
            {
                foreach (Human player in gamePlayers)
                {
                    player.playerWallet.TotalDollars = randomNumber.Next(10, 20);
                }
            }
        }
        public void DisplayPlayerWallet()
        {
            foreach (Human player in gamePlayers)
            {
                Console.WriteLine("{0} has {1} dollars.",player.PlayerName, player.playerWallet.TotalDollars);
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
                case "sell":
                    Console.WriteLine("Okay {0}, before we can sell we have to make the lemonade.",gamePlayer.PlayerName);//breaks here when the game starts.
                    ExecuteSellOptions(gamePlayer);
                    break;
                case "sales tracking":
                    break;
                case "finish day":
                    //include destory lemonade cups here
                    break; 
            }
        }
        private void ExecuteStoreOptions(Human gamePlayer)
        {
            string userSelectedItem;
            decimal purchaseQuantity;
            decimal itemPrice;
            decimal transactionAmount;
            bool customerConfirmation;
            bool fundConfirmation;
            bool shoppingResponse;

            userSelectedItem = SelectItemToPurchase(gamePlayer);
            purchaseQuantity = SelectPurchaseAmount(userSelectedItem);           
            itemPrice = gameStore.DetermineItemPrice(userSelectedItem);       
            transactionAmount = CalculatePrice(purchaseQuantity,itemPrice);            
            customerConfirmation = ConfirmPurchase();          
            fundConfirmation = VerifyFundsForPurchase(transactionAmount, gamePlayer);
            RemoveFundsAfterPurchase(customerConfirmation, fundConfirmation, gamePlayer, transactionAmount);
            gamePlayer.AddPurchaseItemToInventory(userSelectedItem, purchaseQuantity, customerConfirmation, fundConfirmation);
            DisplayInventory(gamePlayer);
            DisplayPlayerFunds();            
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
        private bool VerifyFundsForPurchase(decimal transactionAmount, Human gamePlayer)
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
        public void RemoveFundsAfterPurchase(bool customerConfirmation, bool fundsConfirmation, Human gamePlayer, decimal transactionAmount)
        {
            if (customerConfirmation == true && fundsConfirmation == true)
            {
                gamePlayer.playerWallet.TotalDollars = gamePlayer.playerWallet.TotalDollars - transactionAmount;
            }
        }
        public void DisplayPlayerFunds()
        {
            foreach (Human gamePlayer in gamePlayers)
            {
                Console.WriteLine("{0} has {1} dollars in their wallet", gamePlayer.PlayerName, gamePlayer.playerWallet.TotalDollars);
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
        private void ExecuteSellOptions(Human gamePlayer)
        {
            int amountToMake;
            int lemonAmount;
            int iceCubeAmount;
            int sugarCubeAmount;
            decimal lemonadeSellingPrice;
            string lemonadeTaste;
            DisplayInventory(gamePlayer);
            amountToMake = SelectCupAmount(gamePlayer);
            lemonAmount = SelectLemonAmount(gamePlayer);
            iceCubeAmount = SelectIceCubeAmount(gamePlayer);
            sugarCubeAmount =  SelectSugarCubeAmount(gamePlayer);
            lemonadeTaste = DetermineTaste(lemonAmount, iceCubeAmount, sugarCubeAmount);
            DisplayTaste(lemonadeTaste);
            lemonadeSellingPrice = DetermineSellingPrice();
            gamePlayer.CreateLemonadeCups(lemonadeTaste, amountToMake, lemonadeSellingPrice, gamePlayer);
            gamePlayer.RemoveInventory(lemonAmount, iceCubeAmount, sugarCubeAmount, amountToMake);
            DisplayInventory(gamePlayer);
        }
        private void DisplayInventory(Human gamePlayer)
        {
            Console.WriteLine("{0}, here is what you have in inventory:",gamePlayer.PlayerName);
            Console.WriteLine("{0} - Lemons", gamePlayer.gameInventory.gameLemons.Count);
            Console.WriteLine("{0} - Ice Cubes", gamePlayer.gameInventory.gameIceCubes.Count);
            Console.WriteLine("{0} - Sugar Cubes", gamePlayer.gameInventory.gameSugarCubes.Count);
            Console.WriteLine("{0} - Cups", gamePlayer.gameInventory.gameCups.Count);
            Console.WriteLine("{0} - Lemonade Cups", gamePlayer.gameInventory.gameLemonadeCups.Count);
        }
        private int SelectCupAmount(Human gamePlayer)    
        {
            int amountRequested;
            bool cupConfirmation;
            cupConfirmation = false;
            while (cupConfirmation == false)
            {
                Console.WriteLine("How many cups would you like to make?");
                int.TryParse(Console.ReadLine(), out amountRequested);
                if (amountRequested <= gamePlayer.gameInventory.gameCups.Count)
                {
                    cupConfirmation = true;
                    return amountRequested;
                }
                else
                {
                    Console.WriteLine("You do not have enough cups. Please choose again.");
                }
            }
            return default(int);
        }
        private int SelectLemonAmount(Human gamePlayer)
        {
            int amountRequested;
            bool lemonConfirmation;
            lemonConfirmation = false;
            while (lemonConfirmation == false)
            {
                Console.WriteLine("How many lemons would you like to use? Please choose between '1' and '10'");
                int.TryParse(Console.ReadLine(), out amountRequested);
                if (amountRequested <= gamePlayer.gameInventory.gameLemons.Count && amountRequested <= 10 && amountRequested >= 1)
                {
                    lemonConfirmation = true;
                    return amountRequested;
                }
                else
                {
                    Console.WriteLine("You do not have enough lemons or you choose more than 10. Please choose again.");
                }
            }
            return default(int);
        }
        private int SelectIceCubeAmount (Human gamePlayer)
        {
            int amountRequested;
            bool iceCupConfirmation;
            iceCupConfirmation = false;
            while (iceCupConfirmation == false)
            {
                Console.WriteLine("How many Ice Cubes would you like to use? Please choose between '1' and '10'");
                int.TryParse(Console.ReadLine(), out amountRequested);
                if (amountRequested <= gamePlayer.gameInventory.gameIceCubes.Count && amountRequested <= 10 && amountRequested >= 1)
                {
                    iceCupConfirmation = true;
                    return amountRequested;
                }
                else
                {
                    Console.WriteLine("You do not have enough ice cubes or you did not use an amount between 1 and 10. Please choose again.");
                }
            }
            return default(int);
        }
        private int SelectSugarCubeAmount( Human gamePlayer)
        {
            int amountRequested;
            bool sugarCubeConfirmation;
            sugarCubeConfirmation = false;
            while(sugarCubeConfirmation == false)
            {
                Console.WriteLine("How many Sugar Cubes would you like to use? Please choose between '1' and '10'");
                int.TryParse(Console.ReadLine(), out amountRequested);
                if (amountRequested <= gamePlayer.gameInventory.gameSugarCubes.Count && amountRequested <= 10 && amountRequested >= 1)
                {
                return amountRequested;
                }
                else
                {
                    Console.WriteLine("You do not have enough sugar cubes or you did not use an amount between 1 and 10. Please try again.");
                }
            }
            return default(int);
        }
        private string DetermineTaste(int lemonAmount, int iceCubeAmount, int sugarCubeAmount)
        {
            string lemonadeTaste;
            if (lemonAmount >= sugarCubeAmount )
            {
                decimal taste = (lemonAmount / sugarCubeAmount) - (iceCubeAmount / 5);     
                if (taste >= 2)
                {
                    lemonadeTaste = "sour";
                    return lemonadeTaste;
                }
                else if (taste >= 0)
                {
                    lemonadeTaste = "nuetral";
                    return lemonadeTaste;
                }
            }
            else if (sugarCubeAmount >= lemonAmount)
            {
                decimal taste = (sugarCubeAmount / lemonAmount) - (iceCubeAmount / 5);
                if (taste >= 2)
                {
                    lemonadeTaste = "sweet";
                    return lemonadeTaste;
                }
                else if (taste >= 0)
                {
                    lemonadeTaste = "nuetral";
                    return lemonadeTaste;
                }
            }
            return null;      
        }
        private void DisplayTaste(string lemonadeTaste)
        {
            Console.WriteLine("This batch of lemonade has a {0} taste.",lemonadeTaste);
        }
        private decimal DetermineSellingPrice()
        {
            decimal sellPrice;

            Console.WriteLine("How much would you like to charge? (Please include your dollar and cents - examples: 1.50, .99, .01)");
            try
            {
                decimal.TryParse(Console.ReadLine(), out sellPrice);
                return sellPrice;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Not a valid selection. Please try again.");
                DetermineSellingPrice();
            }
            return default(decimal);
        }

    }
}
