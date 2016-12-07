using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        public Store purchasing;
        public HumanPlayer firstPlayer;
        public UserInterface userEntry;

        public Game()
        {
            purchasing = new Store(firstPlayer);
            userEntry = new UserInterface();
            firstPlayer = new HumanPlayer();   
        }
        public void GameLoop()
        {
            firstPlayer.playerWallet.SelectGameLevel();
            firstPlayer.playerWallet.SetBeginningPlayerBank();
            firstPlayer.playerWallet.DisplayPlayerBank();
            purchasing.IdentifyItem();
            purchasing.IdentifyItemAmount();
            purchasing.SetTransactionAmount();
            purchasing.SetConfirmation(firstPlayer);
            purchasing.displayConfirmation();
            purchasing.collectFunds(firstPlayer);
            firstPlayer.playerWallet.DisplayPlayerBank();
            firstPlayer.gameInventory.AddInventory();

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
