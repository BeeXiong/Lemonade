using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class HumanPlayer : Player
    {
        public Wallet playerWallet;
        public Inventory gameInventory;

        public HumanPlayer()
        {
            playerWallet = new Wallet();
            gameInventory = new Inventory();
        }

        public override void NamePlayers()
        {
            base.NamePlayers();
        }
        public void RemoveTransactionAmount()
        {

        }
        
    }
}
