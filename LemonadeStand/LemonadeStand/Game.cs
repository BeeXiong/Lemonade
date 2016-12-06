using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Store purchasing;
        Inventory gameInventory;
        HumanPlayer firstPlayer;
        
        public Game()
        {
            purchasing = new Store();
            gameInventory = new Inventory();
            firstPlayer = new HumanPlayer();
        }
        public void GameLoop()
        {
 
        }

    }
}
