using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        private decimal transactionAmount;
        public HumanPlayer firstPlayer;
        public Lemon newLemon;
        public Cup newCup;
        public SugarCubes newSugarCube;
        public IceCube newIceCube;

        public Store(HumanPlayer firstPlayer,Lemon newLemon, Cup newCup, SugarCubes newSugarCube, IceCube newIceCube)
        {
            this.firstPlayer = firstPlayer;
           
            this.newLemon = newLemon;
            this.newCup = newCup;
            this.newSugarCube = newSugarCube;
            this.newIceCube = newIceCube;
        }

        public void SetTransactionAmount()
        {
            if (firstPlayer.userEntry.GetItemSelection() == "lemons")
            {
                newLemon.SetPrice();
                transactionAmount = newLemon.GetPrice() * firstPlayer.userEntry.GetPurchaseAmount();
            }
            else if (firstPlayer.userEntry.GetItemSelection() == "cups")
            {
                newCup.SetPrice();
                transactionAmount = newCup.GetPrice() * firstPlayer.userEntry.GetPurchaseAmount();
            }
            else if (firstPlayer.userEntry.GetItemSelection() == "sugar cubes")
            {
                newSugarCube.SetPrice();
                transactionAmount = newSugarCube.GetPrice() * firstPlayer.userEntry.GetPurchaseAmount();
            }
            else if (firstPlayer.userEntry.GetItemSelection() == "ice cubes")
            {
                newIceCube.SetPrice();
                transactionAmount = newIceCube.GetPrice() * firstPlayer.userEntry.GetPurchaseAmount();
            }
        }
        public decimal GetTransactionAmount()
        {
            return transactionAmount;
        }
        public void DisplayTransactionAmount()
        {
            Console.WriteLine(GetTransactionAmount());
        }
        public bool ConfirmFunds()
        {
            if (GetTransactionAmount() <= firstPlayer.playerWallet.playerBank)
            {
                return true; 
            }
            else
            {
                return false;
            }

        }
    }
    
}
