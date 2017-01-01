using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public Store purchasing;
        public HumanPlayer firstPlayer;
        public UserInterface userDisplay;
        public Day gameDay;
        public int userDeterminedGameDay;

        public Game()
        {
            purchasing = new Store();
            userDisplay = new UserInterface();
            firstPlayer = new HumanPlayer();
            gameDay = new Day();
        }
        public void GameLoop()
        {
            firstPlayer.playerWallet.SelectGameLevel();
            firstPlayer.playerWallet.SetBeginningPlayerBank();
            firstPlayer.playerWallet.DisplayPlayerBank();
            //SetGameDays();
            //AddGameDays();
            //SetWeatherConditions();
            //AddWeatherConditions();

            purchasing.IdentifyItem();
            purchasing.IdentifyItemAmount();
            purchasing.SetTransactionAmount();
            purchasing.SetConfirmation(firstPlayer);
             purchasing.CompleteItemSale(firstPlayer);
            firstPlayer.AddIceCubeInventory(firstPlayer.gameInventory.GetIceCubeQuantity());
            firstPlayer.gameInventory.DisplayInventory();
            firstPlayer.playerWallet.DisplayPlayerBank();
            firstPlayer.SetDailyLemonadeCupInventory();
            firstPlayer.SetLemonCupTaste();
            firstPlayer.MakeLemonadeCups();
            firstPlayer.SubtractInventory();
            
        }
        public void SetGameDays()
        {
            Console.WriteLine("How many days would you like to play");
            string userInput = Console.ReadLine();
            userDeterminedGameDay = Convert.ToInt16(userInput);
        }
        public void AddGameDays()
        {
            for (int index = 1; index <= userDeterminedGameDay; index++)
            {
                gameDay.totalGameDays.Add(new Day());
            }
        }
        public void SetWeatherConditions()
        {
            Console.WriteLine("How many days would you like to play");
            string userInput = Console.ReadLine();
            userDeterminedGameDay = Convert.ToInt16(userInput);
        }
        public void AddWeatherConditions()
        {
            for (int index = 1; index <= userDeterminedGameDay; index++)
            {
                gameDay.conditions.weatherConditions.Add(new Weather());
            }
        }

        //public void DisplayOptions()
        //{
        //    Console.WriteLine("What would you like to access? Please choose from one of the following: ");
        //    Console.WriteLine("Rules");
        //    Console.WriteLine("Store");
        //    Console.WriteLine("Kitchen");
        //    Console.WriteLine("Lemonade Sales");
        //    string userinput = Console.ReadLine().ToLower();
        //    switch (userinput)
        //    {
        //        case "Rules":
        //            DisplayRules();
        //            break;
        //        case "Store":

        //        case "Kitchen":
        //        case "Lemonade Sales":
        //            break;
        //    }
        //}





    }
}
