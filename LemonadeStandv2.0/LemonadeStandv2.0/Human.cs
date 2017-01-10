using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Human : Player
    {
        public string PlayerName { get; set; }
        public Human()
        {
            NamePlayers();
        }
        public void NamePlayers()
        {
            Console.WriteLine("Please enter the name for this Player");
            PlayerName = Console.ReadLine();
        }
        public void AddPurchaseItemToInventory(string item, decimal quantity, bool confirmedPurchase, bool confirmedFunds)
        {
            int i;
            if(confirmedPurchase == true && confirmedFunds == true && item == "lemons")
            {
                for (i=0; i<quantity; i++)
                {
                    gameInventory.gameLemons.Add(new Lemon());
                }   
            }
            else if (confirmedPurchase == true && confirmedFunds == true && item == "ice cubes")
            {
                for (i = 0; i < quantity; i++)
                {
                    gameInventory.gameIceCubes.Add(new IceCube());
                }
            }
            else if (confirmedPurchase == true && confirmedFunds == true && item == "sugar cubes")
            {
                for (i = 0; i < quantity; i++)
                {
                    gameInventory.gameSugarCubes.Add(new SugarCube());
                }
            }
            else if (confirmedPurchase == true && confirmedFunds == true && item == "cups")
            {
                for (i = 0; i < quantity; i++)
                {
                    gameInventory.gameCups.Add(new Cup());
                }
            }
        }
        public void CreateLemonadeCups(string lemonadeTaste, int amountToMake, decimal sellingPrice, Human gamePlayer)
        {
            int i;
            for (i = 1; i <= amountToMake; i++)
            {
                gamePlayer.gameInventory.gameLemonadeCups.Add(new LemonadeCup(sellingPrice, lemonadeTaste));
            }
        }

        public void RemoveInventory(int lemonAmount, int iceCubeAmount, int sugarCubeAmount, int cupAmount)
        {
            int i;
            for (i=0; i<=lemonAmount; i++)
            {
                gameInventory.gameLemons.RemoveAt(0);
            }
            for (i = 0; i <= iceCubeAmount; i++)
            {
                gameInventory.gameIceCubes.RemoveAt(0);
            }
            for(i = 0; i <= sugarCubeAmount; i++)
            {
                gameInventory.gameSugarCubes.RemoveAt(0);
            }
            for (i = 0; i <= cupAmount; i++)
            {
                gameInventory.gameCups.RemoveAt(0);
            }
        }
    }
}
