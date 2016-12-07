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
        public Inventory gameInventory;
        public HumanPlayer firstPlayer;
        public Wallet playerWallet;
        public Lemon newLemon;
        public Cup newCup;
        public SugarCubes newSugarCube;
        public IceCube newIceCube;
       

        public Game()
        {
            purchasing = new Store(firstPlayer, newLemon, newCup, newSugarCube, newIceCube);
            gameInventory = new Inventory();
            firstPlayer = new HumanPlayer();
        }
        public void GameLoop()
        {
            firstPlayer.userEntry.SelectGameLevel();


            firstPlayer.userEntry.IdentifyItem();
           
           
            purchasing.SetTransactionAmount();
            purchasing.DisplayTransactionAmount();

            //remove from wallet
            gameInventory.AddInventory();
            gameInventory.DisplayInventory();
            purchasing.ConfirmFunds();
        }

    }
}
