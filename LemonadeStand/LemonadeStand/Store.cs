using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        private string selectedItem;
        private int selectedAmount;
        private double transactionAmount;

        public Store()
        {
            
        }

        public void IdentifyItem()//need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("What would you like to purchase?");
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
                    setPurchaseItem(userInput);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    IdentifyItem();
                    break;
            }
        }
        public void setPurchaseItem(string userInput)
        {
            selectedItem = userInput;
        }
        public string getPurchaseItem()
        {
            return selectedItem;
        }
        public void SetItemAmount()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("You have selected {0}", getPurchaseItem());
            Console.WriteLine("How many {0} would you like to purchase", getPurchaseItem());
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out selectedAmount);
        }
        public int getPurchaseAmount()
        {
            return selectedAmount;
        }

        public void SetTransactionAmount(Lemon newLemon, IceCube newIceCube, Cup newCup, SugarCubes newSugarCube)
        {
            if (selectedItem == "lemons")
            {
                transactionAmount == newLemon.SetPrice() * getPurchaseAmount();
            }
            else if (selectedItem == "cups")
            {
                newCup.SetPrice();
            }
            else if (selectedItem == "sugar cubes")
            {
                newSugarCube.SetPrice();
            }
            else if (selectedItem == "ice cubes")
            {
                newIceCube.SetPrice();
            }
        }

    
        
    }
    
}
