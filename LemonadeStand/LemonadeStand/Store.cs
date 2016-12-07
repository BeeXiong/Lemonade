using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        string purchaseItem;
        decimal purchaseAmount;
        decimal transactionAmount;
        public decimal lemonprice;
        private decimal cupPrice;
        private decimal iceCubePrice;
        private decimal sugarCubePrice;
        bool confirmation;
        HumanPlayer firstPlayer;
        
        public Store(HumanPlayer firstPlayer)
        {
            this.firstPlayer = firstPlayer;
        }
        public void IdentifyItem()//need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("What would you like?");
            Console.WriteLine("Lemons");
            Console.WriteLine("Ice Cubes");
            Console.WriteLine("Sugar Cubes");
            Console.WriteLine("Cups");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "lemons":
                case "ice cubes":
                case "sugar cubes":
                case "cups":
                    SetPurchaseItemSelection(userInput);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    IdentifyItem();
                    break;
            }
        }
        public void SetPurchaseItemSelection(string userInput)
        {
            purchaseItem = userInput;
        }
        public string GetPurchaseItemSelection()
        {
            return purchaseItem;
        }
        public void IdentifyItemAmount()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("You have selected {0}", GetPurchaseItemSelection());
            Console.WriteLine("How many {0} would you like", GetPurchaseItemSelection());
            string userInput = Console.ReadLine();
            decimal.TryParse(userInput, out purchaseAmount);
        }
        public decimal GetPurchaseAmount()
        {
            return purchaseAmount;
        }
        public void SetLemonPrice()
        {
            lemonprice = .25m;
        }
        public decimal GetLemonPrice()
        {
            return lemonprice;
        }
        public void findLemonPrice()
        {
            Console.WriteLine(GetLemonPrice());
        }
        public void SetCupPrice()
        {
            cupPrice = .10m;
            Console.WriteLine(cupPrice);
        }
        public decimal GetCupPrice()
        {
            return cupPrice;
        }
        public void findCupPrice()
        {
            Console.WriteLine(GetCupPrice());
        }
        public void SetIceCubePrice()
        {
            iceCubePrice = .01m;
            Console.WriteLine(iceCubePrice);
        }
        public decimal GetIceCubePrice()
        {
            return iceCubePrice;
        }
        public void findIceCubePrice()
        {
            Console.WriteLine(GetIceCubePrice());
        }
        public void SetSugarCubePrice()
        {
            sugarCubePrice = .01m;
            Console.WriteLine(sugarCubePrice);
        }
        public decimal GetSugarCubePrice()
        {
            return sugarCubePrice;
        }
        public void findSugarCubePrice()
        {
            Console.WriteLine(GetSugarCubePrice());
        }
        public void SetTransactionAmount()
        {
            string itemSelection = GetPurchaseItemSelection();
            if (itemSelection == "lemons")
            {
                SetLemonPrice();
                transactionAmount = GetLemonPrice() * GetPurchaseAmount();
            }
            else if (itemSelection == "cups")
            {
                SetCupPrice();
                transactionAmount = GetCupPrice() * GetPurchaseAmount();
            }
            else if (itemSelection == "sugar cubes")
            {
                SetSugarCubePrice();
                transactionAmount = GetSugarCubePrice() * GetPurchaseAmount();
            }
            else if (itemSelection == "ice cubes")
            {
                SetIceCubePrice();
                transactionAmount = GetIceCubePrice() * GetPurchaseAmount();
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
        public void SetConfirmation(HumanPlayer firstPlayer)
        {
            if (GetTransactionAmount() <= firstPlayer.playerWallet.GetPlayerBank())
            {
                confirmation = true;
            }
            else
            {
                confirmation = false;
            }
        }
        public bool getConfirmation()
        {
            return confirmation;
        }
        public void displayConfirmation()
        {
            Console.WriteLine("{0}", getConfirmation());
        }
        public void collectFunds(HumanPlayer firstPlayer)
        {
            if (getConfirmation() == true)
            {
                decimal AmountRemaning = firstPlayer.playerWallet.GetPlayerBank() - GetTransactionAmount();
                firstPlayer.playerWallet.SetPlayerBank(AmountRemaning);
            }
        }
    }
}
