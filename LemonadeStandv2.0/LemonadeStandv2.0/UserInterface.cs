using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class UserInterface
    {
        public void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Lemonade Stand!");
            Console.WriteLine("\r\nHere are the rules.");
            Console.WriteLine("Player selects the total number of days to play");
            Console.WriteLine("During each day a player can:");
            Console.WriteLine("   - Purchase items");
            Console.WriteLine("   - Choose some ingredients and make cups of lemonade");
            Console.WriteLine("   - Set the price of the lemonade");
            Console.WriteLine("   - Sell lemonade and MAKE MONEY!");
            Console.WriteLine("\r\nAt the end of the day, find out how much you made");
        }
        public void DisplayRules()
        {
            Console.WriteLine("Game Rules:");
            Console.WriteLine("\r\nPlayers must have enough money to purchase items");
            Console.WriteLine("Weather conditions which change daily will impact lemonade sales");
            Console.WriteLine("Customers preference on the taste of the lemonade will impact sales");
            Console.WriteLine("Price will impact lemonade sales");
            Console.WriteLine("\r\nPlayers must maintain a balance of at least $.01 to continue playing");
            Console.WriteLine("Players will need to go bankrupt to start again.");
        }
        public void DisplayOptions()
        {
            Console.WriteLine("What would you like to access? Please choose from one of the following: ");
            Console.WriteLine("Rules");
            Console.WriteLine("Store");
            Console.WriteLine("Sell");
            Console.WriteLine("To finish your day, please type 'Finish Day'");
        }
        public void ClearScreen()
        {
            Console.Clear();
        }
        public void RequestContinue()
        {
            Console.WriteLine("\r\nPress any ENTER to continue");
            
Console.ReadLine();
        }
    }
}
