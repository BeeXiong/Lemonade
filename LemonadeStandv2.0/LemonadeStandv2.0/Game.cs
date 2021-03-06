﻿using System;
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
            int userGameDaySelection;
            int numberOfPlayers;
            string userSelectedGameLevel;
            gameInformation = new UserInterface();
            gameInformation.DisplayWelcome();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            gameInformation.DisplayRules();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            userGameDaySelection = SelectNumberOfGameDays();
            AddGameDays(userGameDaySelection, rndNumber);
            DisplayTotalGameDays();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            numberOfPlayers = SelectNumberOfPlayers();
            CreatePlayers(numberOfPlayers);
            DisplayPlayers();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            userSelectedGameLevel = SelectGameLevel();
            SetBeginningPlayerBank(userSelectedGameLevel,rndNumber);
            DisplayPlayerWallet();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            while (gamePlayers.Count != 0 && selectedGameDays.Count > 0)
            {
                foreach (Human gamePlayer in gamePlayers)
                {
                    gameInformation.ClearScreen();
                    Console.WriteLine("Okay, {0}.", gamePlayer.PlayerName);
                    gameInformation.DisplayOptions();
                    ReceiveOptionRequest(gameInformation, gamePlayer,rndNumber);
                }
            }
            if (selectedGameDays.Count == 0)
            {
                Console.WriteLine("You have completed a total of {0} game days! Thanks for playing Lemonade Stand! Come Back again.",userGameDaySelection);
                Console.WriteLine("Press Enter to Exit");
                Console.ReadLine();
            }
            else if (gamePlayers.Count == 0)
            {
                Console.WriteLine("O. You don't have enough money to continue. Thanks for playing Lemonade Stand! Come Back again.");
                Console.WriteLine("Press Enter to Exit");
                Console.ReadLine();
            }
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
            for (i = 0; i < userGameDays; i++)
            {
                selectedGameDays.Add(new Day(randomNumber));
            }
        }
        public void DisplayTotalGameDays()
        {
            Console.WriteLine("Okay. We are playing for {0} days",selectedGameDays.Count);
        }
        //public int SelectNumberOfPlayers()
        //{
        //    string userInput;
        //    int cvtUserInput;
        //    Console.WriteLine("Please select the number of players");
        //    userInput = Console.ReadLine();
        //    if (Regex.IsMatch(userInput, @"^\d+$"))
        //    {
        //        int.TryParse(userInput, out cvtUserInput);
        //        return cvtUserInput;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not a valid selection. Please try again.\n");
        //    }
        //    return SelectNumberOfPlayers();
        //}
        public int SelectNumberOfPlayers()
        {
            return 1;
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
            Console.WriteLine("\nOkay. Here's the list of players for this game");
            foreach (Human player in gamePlayers)
            {
                Console.WriteLine(player.PlayerName);
            }
        }
        public string SelectGameLevel()
        {
            Console.WriteLine("\nPlease select game level. 'Easy' - 'Medium' - 'Hard' ");
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
                        break;
                }
                return SelectGameLevel();
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
            List<Day> weeklyForcasts;

            switch (userinput)
            {
                case "rules":
                    gameInfo.ClearScreen();
                    gameInfo.DisplayRules();
                    gameInfo.RequestContinue();
                    gameInfo.DisplayOptions();
                    ReceiveOptionRequest(gameInfo, gamePlayer,randomNumber);
                    break;
                case "store":
                    gameInfo.ClearScreen();
                    ExecuteStoreOptions(gamePlayer,gameInfo);
                    break;
                case "sell":
                    gameInfo.ClearScreen();
                    weeklyForcasts = GenerateWeeklyForcast(randomNumber);
                    DisplayWeeklyForcast(weeklyForcasts);
                    gameInfo.RequestContinue();
                    if (gamePlayer.gameInventory.gameCups.Count < 1 || gamePlayer.gameInventory.gameLemons.Count < 1 || gamePlayer.gameInventory.gameIceCubes.Count < 1 || gamePlayer.gameInventory.gameSugarCubes.Count < 1)
                    {
                        Console.WriteLine("You must go to the store before we can make and sell lemonade.");
                        gameInfo.RequestContinue();
                        gameInfo.ClearScreen();
                        gameInfo.DisplayOptions();
                        ReceiveOptionRequest(gameInfo, gamePlayer,randomNumber);
                    }
                    else
                    {
                        Console.WriteLine("Okay {0}, before we can sell we have to make the lemonade.", gamePlayer.PlayerName);//breaks here when the game starts.
                        ExecuteSellOptions(gamePlayer,randomNumber,gameInfo);
                        Console.WriteLine("Okay. The day is done!. Moving on to the next day.");
                        selectedGameDays.RemoveAt(0);
                        gameInfo.RequestContinue();
                        gameInfo.ClearScreen();
                    }
                    break;
                case "finish day":
                    Console.WriteLine("Okay. The day is done!. Moving on to the next day.");
                    selectedGameDays.RemoveAt(0);
                    gameInfo.RequestContinue();
                    gameInfo.ClearScreen();
                    break;
                default:
                    Console.WriteLine("Invalid Entry. Please select either 'rules' - 'store' - 'sell' or 'finish day'");
                    gameInfo.RequestContinue();
                    break;
            }
        }
        private List<Day> GenerateWeeklyForcast(Random randomNumber)
        {
            List<Day> gameForcasts = new List<Day>();
            int arrayLength;
            int tempConditionNumber;
            decimal tempNumber;
            arrayLength = selectedGameDays.Count()-1;
            tempNumber = randomNumber.Next(1, 10);
            tempConditionNumber = randomNumber.Next(1, 3);
            for (int i = 0; i < 5 && i <= arrayLength; i++)
            {
                gameForcasts.Add(new Day(randomNumber));
                if (tempNumber % 2 == 0)
                {
                    gameForcasts[i].WeatherCondition.Temperature = selectedGameDays[i].WeatherCondition.Temperature - tempNumber;
                }
                else
                {
                    gameForcasts[i].WeatherCondition.Temperature = selectedGameDays[i].WeatherCondition.Temperature + tempNumber;
                }
                if (tempConditionNumber == 1)
                {
                    gameForcasts[i].WeatherCondition.Condition = "sunny";
                }
                else if (tempConditionNumber == 2)
                {
                    gameForcasts[i].WeatherCondition.Condition = "raining";
                }
                else
                {
                    gameForcasts[i].WeatherCondition.Condition = "cloudy";
                }
            }
            return gameForcasts;
        }
        private void DisplayWeeklyForcast(List<Day> forcastDays)
        {
            Console.WriteLine("Here's what the weather looks like for week.");
            int arrayLength;
            int i = 0;
            arrayLength = forcastDays.Count();
            for (i=0; i < 5 && i < arrayLength; i++)
            {
                Console.WriteLine("Day {0}: Temperature: {1}", i+1, forcastDays[i].WeatherCondition.Temperature);
                Console.WriteLine("Day {0}: Weather Condition: {1}", i+1, forcastDays[i].WeatherCondition.Condition);
            }
        }
        private void ExecuteStoreOptions(Human gamePlayer,UserInterface gameInfo)
        {
            string userSelectedItem;
            decimal purchaseQuantity;
            decimal itemPrice;
            decimal transactionAmount;
            bool customerConfirmation;
            bool fundConfirmation;
            bool shoppingResponse;

            DisplayInventory(gamePlayer);
            userSelectedItem = SelectItemToPurchase(gamePlayer);
            purchaseQuantity = SelectPurchaseAmount(userSelectedItem);           
            itemPrice = gameStore.DetermineItemPrice(userSelectedItem);       
            transactionAmount = CalculatePrice(purchaseQuantity,itemPrice);            
            customerConfirmation = ConfirmPurchase();          
            fundConfirmation = VerifyFundsForPurchase(transactionAmount, gamePlayer);
            RemoveFundsAfterPurchase(customerConfirmation, fundConfirmation, gamePlayer, transactionAmount);
            gamePlayer.AddPurchaseItemToInventory(userSelectedItem, purchaseQuantity, customerConfirmation, fundConfirmation);
            gameInfo.RequestContinue();
            gameInfo.ClearScreen();
            DisplayInventory(gamePlayer);
            DisplayPlayerFunds();            
            shoppingResponse = PromptToContinueShopping();
            gameInformation.ClearScreen();
            ContinueShopping(shoppingResponse,gamePlayer,gameInfo);
        }
        private string SelectItemToPurchase(Human gamePlayer)
        {
            Console.WriteLine("\nOkay {0}. What would you like to purchase?",gamePlayer.PlayerName);
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
                    Console.WriteLine("\nYou have choosen {0}", userItemSelection);
                    return userItemSelection;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    break;
            }
            return SelectItemToPurchase(gamePlayer);
        }
        private decimal SelectPurchaseAmount(string userItemSelection)
        {
            Console.WriteLine("\nHow many {0} would you like", userItemSelection);
            string userInput = Console.ReadLine();
            if(Regex.IsMatch(userInput, @"^\d+$"))
            {
                decimal purchaseQuantity;
                decimal.TryParse(userInput, out purchaseQuantity);
                return purchaseQuantity;
            }
            else
            {
                Console.WriteLine("Invalid Entry. Please try again");
            }
            return SelectPurchaseAmount(userItemSelection);
        }
        private decimal CalculatePrice(decimal purchaseQuantity, decimal itemPrice)
        {
            decimal transactionPrice;
            transactionPrice = purchaseQuantity * itemPrice;
            Console.WriteLine("\nThe total for this purchase will be {0}",transactionPrice);
            return transactionPrice;
        }
        private bool ConfirmPurchase()
        {
            Console.WriteLine("\nWould you like to purchase this item?");
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
                return ConfirmPurchase(); ;             
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
                return PromptToContinueShopping();
            }
            else
            {
                return false;
            }
        }
        private void ContinueShopping(bool shoppingResponse,Human gamePlayer, UserInterface gamePrompt)
        {
            if (shoppingResponse == true)
            {
                ExecuteStoreOptions(gamePlayer,gamePrompt);
            }
            else
            {
                Console.WriteLine("Alright {0}, Thanks for shopping!",gamePlayer.PlayerName);
            }
        }
        private void ExecuteSellOptions(Human gamePlayer,Random randomNumber,UserInterface gameInfo)
        {
            int amountToMake;
            int lemonAmount;
            int iceCubeAmount;
            int sugarCubeAmount;
            int supplyDemandModifier;
            decimal dailyNumberOfSales;
            decimal lemonadeSellingPrice;
            decimal dailyRevenue;
            decimal totalGameRevenue;
            decimal totalGameTransactions;
            string lemonadeTaste;
            Day currentGameDay;
            DisplayInventory(gamePlayer);
            amountToMake = SelectCupAmount(gamePlayer,gameInfo);
            lemonAmount = SelectLemonAmount(gamePlayer,gameInfo);
            iceCubeAmount = SelectIceCubeAmount(gamePlayer,gameInfo);
            sugarCubeAmount =  SelectSugarCubeAmount(gamePlayer,gameInfo);
            lemonadeTaste = DetermineTaste(lemonAmount, iceCubeAmount, sugarCubeAmount);
            DisplayTaste(lemonadeTaste);
            lemonadeSellingPrice = DetermineSellingPrice(gameInfo);
            StoreDailySellingPrice(lemonadeSellingPrice);
            supplyDemandModifier = IdentifyPriceModifier(lemonadeSellingPrice);
            gamePlayer.CreateLemonadeCups(lemonadeTaste, amountToMake, lemonadeSellingPrice, gamePlayer);
            gamePlayer.RemoveInventory(lemonAmount, iceCubeAmount, sugarCubeAmount, amountToMake);
            DisplayInventory(gamePlayer);
            currentGameDay = SelectCurrentDay();
            DisplayDailyWeather(currentGameDay);
            gameInfo.RequestContinue();
            gameInfo.ClearScreen();
            SellLemonadeCups(currentGameDay,lemonadeTaste,randomNumber,gamePlayer,supplyDemandModifier);
            RemoveLemonadeCupsFromInventory(gamePlayer, currentGameDay);
            dailyNumberOfSales = DetermineDailyNumberOfSales(currentGameDay);
            dailyRevenue = CalculateDailyRevenue(dailyNumberOfSales, lemonadeSellingPrice);
            AddRevenueToBank(gamePlayer, dailyRevenue);
            DisplayDailySales(dailyRevenue, dailyNumberOfSales);
            gameInfo.RequestContinue();
            gameInfo.ClearScreen();
            dailyTransactions = GenerateListOfTransactions(currentGameDay);
            totalGameTransactions = calculateTotalTransactions(dailyTransactions);
            totalGameRevenue = CalculateTotalGameRevenue(dailyTransactions, salePrices);
            DisplayAllSales(totalGameTransactions, totalGameRevenue);
            gameInfo.RequestContinue();
            gameInfo.ClearScreen();
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
        private int SelectCupAmount(Human gamePlayer,UserInterface gameInfo)    
        {
            int amountRequested;
            bool cupConfirmation;
            string userInput;
            cupConfirmation = false;
            while (cupConfirmation == false)
            {
                Console.WriteLine("How many cups would you like to make?");
                userInput = Console.ReadLine();
                try
                {
                    amountRequested = int.Parse(userInput);
                    if (amountRequested <= gamePlayer.gameInventory.gameCups.Count)
                    {
                        //cupConfirmation = true;
                        return amountRequested;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough cups. Please choose again.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry. Please try to enter a number again");
                }
            }
            return default(int);
        }
        private int SelectLemonAmount(Human gamePlayer,UserInterface gameInfo)
        {
            int amountRequested;
            bool lemonConfirmation;
            string userInput;
            lemonConfirmation = false;
            while (lemonConfirmation == false)
            {
                Console.WriteLine("How many lemons would you like to use? Please choose between '1' and '10'");
                userInput = Console.ReadLine();
                try
                {
                    amountRequested = int.Parse(userInput);
                    if (amountRequested <= gamePlayer.gameInventory.gameLemons.Count && amountRequested <= 10 && amountRequested >= 1)
                    {
                        //lemonConfirmation = true;
                        return amountRequested;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Please make sure you have enough Lemons and choose a NUMBER between '1' and '10'. Please try again.");
                        gameInfo.RequestContinue();
                        gameInfo.ClearScreen();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry. Please try to enter a number between '1' and '10'");
                    gameInfo.RequestContinue();
                    gameInfo.ClearScreen();
                }
            }
            return default(int);
        }
        private int SelectIceCubeAmount (Human gamePlayer, UserInterface gameInfo)
        {
            int amountRequested;
            string userInput;
            bool iceCupConfirmation;
            iceCupConfirmation = false;
            while (iceCupConfirmation == false)
            {
                Console.WriteLine("How many Ice Cubes would you like to use? Please choose between '1' and '10'");
                userInput = Console.ReadLine();
                try
                {
                    amountRequested = int.Parse(userInput);
                    if (amountRequested <= gamePlayer.gameInventory.gameIceCubes.Count && amountRequested <= 10 && amountRequested >= 1)
                    {
                        //iceCupConfirmation = true;
                        return amountRequested;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry.Please make sure you have enough Ice Cubes and choose a NUMBER between '1' and '10'.Please try again.");
                        gameInfo.RequestContinue();
                        gameInfo.ClearScreen();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry. Please try to enter a number between '1' and '10'");
                    gameInfo.RequestContinue();
                    gameInfo.ClearScreen();
                }
            }
            return default(int);
        }
        private int SelectSugarCubeAmount(Human gamePlayer, UserInterface gameInfo)
        {
            string userInput;
            int amountRequested;
            bool sugarCubeConfirmation;
            sugarCubeConfirmation = false;
            while(sugarCubeConfirmation == false)
            {
                Console.WriteLine("How many Sugar Cubes would you like to use? Please choose between '1' and '10'");             
                userInput = Console.ReadLine();
                try
                {
                    amountRequested = int.Parse(userInput);
                    if (amountRequested <= gamePlayer.gameInventory.gameSugarCubes.Count && amountRequested <= 10 && amountRequested >= 1)
                    {
                        sugarCubeConfirmation = true;
                        return amountRequested;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Entry. Please make sure you have enough Sugar Cubes and choose a NUMBER between '1' and '10'. Please try again.");
                        gameInfo.RequestContinue();
                        gameInfo.ClearScreen();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Entry. Please try to enter a number between '1' and '10'");
                    gameInfo.RequestContinue();
                    gameInfo.ClearScreen();
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
        private decimal DetermineSellingPrice(UserInterface gameinfo)
        {
            string userInput;
            Console.WriteLine("How much would you like to charge? (Please include your dollar and cents - examples: 1.50, .99, .01)");
            userInput = Console.ReadLine();
            try
            {
                return decimal.Parse(userInput);
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid selection. Please try again. (Please include your dollar and cents - examples: 1.50, .99, .01)");
                return DetermineSellingPrice(gameinfo);
            } 
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
            Console.WriteLine("\nOkay. Let's sell some Lemonade");
            Console.WriteLine("Here's what the weather looks like for today.");
            Console.WriteLine("Temperature: {0}", currentDay.WeatherCondition.Temperature);
            Console.WriteLine("Weather Condition: {0}", currentDay.WeatherCondition.Condition);
        }
        private int IdentifyPriceModifier(decimal dailySalePrice)
        {
            if (dailySalePrice >= 1.5m)
            {
                return 3;
            }
            else if (dailySalePrice >= .8m)
            {
                return 2;
            }
            return 1;
        }
        private void SellLemonadeCups(Day currentDay, string lemonadeTaste, Random randomNumber, Human gamePlayer, int priceModifier)
        {
            int totalLemonadeCups;

            foreach (Customer potientialCustomer in currentDay.lemonadeCustomers)
            {
                totalLemonadeCups = gamePlayer.gameInventory.gameLemonadeCups.Count();
                Console.WriteLine("\nA new customer is approaching");
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(100);
                if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 80 && totalLemonadeCups!=0)
                {
                    decimal chanceTobuy = (1 * priceModifier);
                    if (chanceTobuy == 1)
                     {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                        }
                    }
                else if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 60 && totalLemonadeCups != 0)
                {
                    decimal chanceTobuy = randomNumber.Next(1, (2 * priceModifier));
                    if (chanceTobuy == 1)
                    {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                    }
                }
                else if (potientialCustomer.TastePreference == lemonadeTaste && currentDay.WeatherCondition.Temperature > 80 && currentDay.WeatherCondition.Condition == "raining" && totalLemonadeCups != 0)
                {
                    decimal chanceTobuy = randomNumber.Next(1, (3 * priceModifier));
                    if (chanceTobuy == 1)
                    {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                    }
                }
                if (potientialCustomer.TastePreference != lemonadeTaste && currentDay.WeatherCondition.Temperature > 80 && totalLemonadeCups != 0)
                {
                    decimal chanceTobuy = randomNumber.Next(1, (5 * priceModifier));
                    if (chanceTobuy == 1)
                    {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                    }
                }
                else if (potientialCustomer.TastePreference != lemonadeTaste && currentDay.WeatherCondition.Temperature > 60 && totalLemonadeCups != 0)
                {
                    decimal chanceTobuy = randomNumber.Next(1, (7 * priceModifier));
                    if (chanceTobuy == 1)
                    {
                        currentDay.purchasingCustomers.Add(potientialCustomer);
                        gamePlayer.gameInventory.gameLemonadeCups.RemoveAt(0);
                        Console.WriteLine("The customer purchased some lemonade!");
                    }
                }
                else if (totalLemonadeCups == 0)
                {
                    Console.WriteLine("You are out of Lemonade for the day!");
                    break;
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
        private void AddRevenueToBank(Human gamePlayer, decimal dailyRevenue)
        {
            gamePlayer.playerWallet.TotalDollars = gamePlayer.playerWallet.TotalDollars + dailyRevenue;
        }
        private void DisplayDailySales(decimal dailyAmountOfSales, decimal transactionsForDay)
        {
            Console.WriteLine("Today, you made {0} dollars today off of {1} transactions.", dailyAmountOfSales, transactionsForDay);
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
            Console.WriteLine("So far, your lemonade stand has made {0} dollars total off of {1} total transactions",totalGameRevenue,totalGameTransactions);
        }
    }
}
