using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class HumanPlayer : Player
    {
        public UserInterface userEntry;
        public Wallet playerWallet;
        public HumanPlayer()
        {
            playerWallet = new Wallet();
            userEntry = new UserInterface();
        }

        public override void NamePlayers()
        {
            base.NamePlayers();
        }

        public void SetPlayerBank()
        {
            string difficultyLevel = userEntry.GetItemSelection();
            if (difficultyLevel == "easy")
            {
                Random rnd = new Random();
                decimal playerbank = rnd.Next(30, 40);
            }
            else if (difficultyLevel == "medium")
            {
                Random rnd = new Random();
                decimal playerbank = rnd.Next(20, 30);
            }
            else if (difficultyLevel == "hard")
            {
                Random rnd = new Random();
                decimal playerbank = rnd.Next(10, 20);
            }
        }
        public void DisplayPlayerBank()
        {
            Console.WriteLine(playerWallet.playerBank);
        }
        public void RemoveTransactionAmount()
        {

        }
        
    }
}
