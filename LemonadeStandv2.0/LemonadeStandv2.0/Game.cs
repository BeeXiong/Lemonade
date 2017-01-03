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
        List<Human> gamePlayers;
        Store gameStore;
        Random rnd = new Random();
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
            AddGameDays(userGameDaySelection);
            DisplayTotalGameDays();
            gameInformation.RequestContinue();
            gameInformation.ClearScreen();
            int numberOfPlayers = SelectNumberOfPlayers();
            CreatePlayers(numberOfPlayers);
            DisplayPlayers();
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
            for (i = 0; i <= numberOfPlayers; i++)
            {
                gamePlayers.Add(new Human());
            }
        }
        public void DisplayPlayers()
        {
            Console.WriteLine("Okay. Here's the list of players for this game");
            foreach (Human player in gamePlayers)
            {
                Console.WriteLine(player);
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
                    case "Hard":
                        return userInput;
                    default:
                        Console.WriteLine("Invaild Entry. Please select either 'Easy' - 'Medium' - 'Hard' ");
                        SelectGameLevel();
                        break;
                }
                return null;
            }
        }
        //public void SetBeginningPlayerBank(string userInput)
        //{
        //    string difficultyLevel = userInput;
        //    if (difficultyLevel == "easy")
        //    {
        //        Random rnd = new Random();
        //        playerBank = rnd.Next(30, 40);
        //    }
        //    else if (difficultyLevel == "medium")
        //    {
        //        Random rnd = new Random();
        //        playerBank = rnd.Next(20, 30);
        //    }
        //    else if (difficultyLevel == "hard")
        //    {
        //        Random rnd = new Random();
        //        playerBank = rnd.Next(10, 20);
        //    }
        //}
    }
}
