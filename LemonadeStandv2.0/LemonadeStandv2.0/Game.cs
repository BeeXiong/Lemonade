using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace LemonadeStandv2._0
{
    class Game
    {
        UserInterface gameInformation;
        List<Day> selectedGameDays;
        List<Player> gamePlayers;
        List<decimal> salePrices;
        List<decimal> dailyTransactions;
        Store gameStore;
        Random rndNumber;

        public Game()
        {
            gameStore = new Store();
            rndNumber = new Random();
            salePrices = new List<decimal>();
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
            AddGameDays(userGameDaySelection, rndNumber);
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
                    ReceiveOptionRequest(gameInformation, gamePlayer,rndNumber);
                }
            }
            Console.ReadKey();
        }
        public int SelectNumberOfGameDays()
        {
            string userInput;
            int cvtUserInput;
            Console.WriteLine("Please select the number of days to play.");
            userInput = Console.ReadLine();
            if (Regex.IsMatch(userInput, @"^\d+$"))
            {
                int.TryParse(userInput, out cvtUserInput);
                return cvtUserInput;
            }
            else
            {
                Console.WriteLine("Not a valid selection. Please try again.\n");
            }
            return SelectNumberOfGameDays();
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
        public int SelectNumberOfPlayers()
        {
            string userInput;
            int cvtUserInput;
            Console.WriteLine("Please select the number of players");
            userInput = Console.ReadLine();
            if (Regex.IsMatch(userInput, @"^\d+$"))
            {
                int.TryParse(userInput, out cvtUserInput);
                return cvtUserInput;
            }
            else
            {
                Console.WriteLine("Not a valid selection. Please try again.\n");
            }
            return SelectNumberOfGameDays(); ;
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
        public void ReceiveOptionRequest(UserInterface gameInfo,Human gamePlayer,Random randomNumber)
        {
            string userinput = Console.ReadLine().ToLower();
            switch (userinput)
            {
                case "rules":
                    gameInfo.DisplayRules();
                    gameInfo.RequestContinue();
                    gameInfo.DisplayOptions();
                    ReceiveOptionRequest(gameInfo, gamePlayer,randomNumber);
                    break;
                case "store":
                    ExecuteStoreOptions(gamePlayer);
                    break;
                case "sell":
                    if(gamePlayer.gameInventory.gameCups.Count < 1 || gamePlayer.gameInventory.gameLemons.Count < 1 || gamePlayer.gameInventory.gameIceCubes.Count < 1 || gamePlayer.gameInventory.gameSugarCubes.Count < 1)
                    {
                        Console.WriteLine("You must go to the store before we can make and sell lemonade.");
                        gameInfo.DisplayOptions();
                        ReceiveOptionRequest(gameInfo, gamePlayer,randomNumber);
                    }
                    else
                    {
                        Console.WriteLine("Okay {0}, before we can sell we have to make the lemonade.", gamePlayer.PlayerName);//breaks here when the game starts.
                        ExecuteSellOptions(gamePlayer,randomNumber);
                    }
                    break;
                case "finish day":
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
            Console.WriteLine("How many {0} would you like", userItemSelection);
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
                return false;//bug here due to return false after recursion occurs (event if it returns something from the recursion)
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
        private void ExecuteSellOptions(Human gamePlayer,Random randomNumber)
        {
            int amountToMake;
            int lemonAmount;
            int iceCubeAmount;
            int sugarCubeAmount;
            decimal dailyNumberOfSales;
            decimal lemonadeSellingPrice;
            decimal dailyRevenue;
            decimal totalGameRevenue;
            decimal totalGameTransactions;
            string lemonadeTaste;
            Day currentGameDay;
            DisplayInventory(gamePlayer);
            amountToMake = SelectCupAmount(gamePlayer);
            lemonAmount = SelectLemonAmount(gamePlayer);
            iceCubeAmount = SelectIceCubeAmount(gamePlayer);
            sugarCubeAmount =  SelectSugarCubeAmount(gamePlayer);
            lemonadeTaste = DetermineTaste(lemonAmount, iceCubeAmount, sugarCubeAmount);
            DisplayTaste(lemonadeTaste);
            lemonadeSellingPrice = DetermineSellingPrice();
            StoreDailySellingPrice(lemonadeSellingPrice);
            gamePlayer.CreateLemonadeCups(lemonadeTaste, amountToMake, lemonadeSellingPrice, gamePlayer);
            gamePlayer.RemoveInventory(lemonAmount, iceCubeAmount, sugarCubeAmount, amountToMake);
            DisplayInventory(gamePlayer);
            currentGameDay = SelectCurrentDay();
            DisplayDailyWeather(currentGameDay);
            SellLemonadeCups(currentGameDay,lemonadeTaste,randomNumber,gamePlayer);
            RemoveLemonadeCupsFromInventory(gamePlayer, currentGameDay);
            dailyNumberOfSales = DetermineDailyNumberOfSales(currentGameDay);
            dailyRevenue = CalculateDailyRevenue(dailyNumberOfSales, lemonadeSellingPrice);
            DisplayDailySales(dailyRevenue, dailyNumberOfSales);
            dailyTransactions = GenerateListOfTransactions(currentGameDay);
            totalGameTransactions = calculateTotalTransactions(dailyTransactions);
            totalGameRevenue = CalculateTotalGameRevenue(dailyTransactions, salePrices);
            DisplayAllSales(totalGameTransactions, totalGameRevenue);
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
        private int SelectSugarCubeAmount(Human gamePlayer)
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

            }
            else
            {
                lemonadeTaste = "nuetral";
                return lemonadeTaste;
            }
            return null;      
        }
        private void DisplayTaste(string lemonadeTaste)
        {
            Console.WriteLine("This batch of lemonade has a {0} taste.",lemonadeTaste);
        }
        private decimal DetermineSellingPrice()//make this into a while loop for verification
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
        private void StoreDailySellingPrice(decimal dailySalePrice)
        {
            salePrices.Add(dailySalePrice);
        }
        private Day SelectCurrentDay()
        {
            Day currentGameDay = selectedGameDays[0];
            return currentGameDay; 
        }
        private void DisplayDailyWeather(Day currentDay)
        { 
            Console.WriteLine("Okay. Let's sell some Lemonade");
            Console.WriteLine("Here's what the weather looks like for today.");
            Console.WriteLine("Temperature: {0}", currentDay.WeatherCondition.Temperature);
        }
        private void SellLemonadeCups(Day currentDay, string lemonadeTaste, Random randomNumber,Human gamePlayer)
        {
            int totalLemonadeCups;
            totalLemonadeCups = gamePlayer.gameInventory.gameLemonadeCups.Count();
            foreach (Customer potientialCustomer in currentDay.lemonadeCustomers)
            {
                Console.WriteLine("A new customer is approaching");
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                if (totalLemonadeCups > 0)
                {
                    if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 80)
                    {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                        
                    }
                    else if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 60)
                    {
                        decimal chanceTobuy = randomNumber.Next(1, 2);
                        if (chanceTobuy == 1)
                        {
                            currentDay.purchasingCustomers.Add(potientialCustomer);
                            gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                            Console.WriteLine("The customer purchased some lemonade!");
                        }
                    }
                    else if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 80 && currentDay.WeatherCondition.Condition == "raining")
                    {
                        decimal chanceTobuy = randomNumber.Next(1, 3);
                        if (chanceTobuy == 1)
                        {
                            currentDay.purchasingCustomers.Add(potientialCustomer);
                            gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                            Console.WriteLine("The customer purchased some lemonade!");
                        }
                    }
                    if (potientialCustomer.TastePreference != lemonadeTaste && currentDay.WeatherCondition.Temperature > 80)
                    {
                        decimal chanceTobuy = randomNumber.Next(1, 5);
                        if (chanceTobuy == 1)
                        {
                            currentDay.purchasingCustomers.Add(potientialCustomer);
                            gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                            Console.WriteLine("The customer purchased some lemonade!");
                        }
                    }
                    else if (potientialCustomer.TastePreference != lemonadeTaste && currentDay.WeatherCondition.Temperature > 60)
                    {
                        decimal chanceTobuy = randomNumber.Next(1, 10);
                        if (chanceTobuy == 1)
                        {
                            currentDay.purchasingCustomers.Add(potientialCustomer);
                            gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                            Console.WriteLine("The customer purchased some lemonade!");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You are out of Lemonade for the day!");
                }
            }
        }
        private void RemoveLemonadeCupsFromInventory(Human gamePlayer, Day currentDay)
        {
            int totalLemonadeCups;
            totalLemonadeCups = gamePlayer.gameInventory.gameLemonadeCups.Count();
            int i;
            for (i = 0; i < totalLemonadeCups; i++)
            { 
               gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);  
            }
        }
        private decimal DetermineDailyNumberOfSales(Day currentDay)
        {
            decimal totalNumberOfSales; 
            totalNumberOfSales = currentDay.purchasingCustomers.Count;
            return totalNumberOfSales;
        }
        private decimal CalculateDailyRevenue(decimal numberOfSales, decimal cupSalePrice)
        {
            return numberOfSales * cupSalePrice;
        }
        private void DisplayDailySales(decimal dailyAmountOfSales, decimal dailytransactions)
        {
            Console.WriteLine("You made {0} dollars today off of {1} transactions.", dailyAmountOfSales,dailyTransactions);
        }
        private List<decimal> GenerateListOfTransactions(Day currentDay)
        {        
            dailyTransactions = new List<decimal>();
            foreach (Day gameDay in selectedGameDays)
            {
                dailyTransactions.Add(gameDay.purchasingCustomers.Count());
            }
            return dailyTransactions;
        }
        private decimal CalculateTotalGameRevenue(List<Decimal> dailyTransactionAmount, List<decimal> dailySalesPrice)
        {
            int i;
            List<decimal> totalRevenue;
            totalRevenue = new List<decimal>();
            i = 0;
            foreach(decimal price in dailySalesPrice)
            {
                totalRevenue.Add(price * dailyTransactionAmount[i]);
            }
            return totalRevenue.Sum();
        }
        private decimal calculateTotalTransactions(List<decimal> gameTransactions)
        {
            return gameTransactions.Sum();

        }
        private void DisplayAllSales(decimal totalGameTransactions, decimal totalGameRevenue)
        {
            Console.WriteLine("You have");
        }
    }
}
