using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        Lemon lemonInventory;
        Cup cupInventory;
        SugarCubes sugarInventory;
        IceCube iceInventory;
        string selectedItem;
        public int selectedAmount;

        public Store()
        {
            this.lemonInventory = new Lemon();
            this.cupInventory = new Cup();
            this.sugarInventory = new SugarCubes();
            this.iceInventory = new IceCube();
        }

        public void IdentifyItem()
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
                    GetPurchaseItem(userInput);
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' - 'Cups' ");
                    IdentifyItem();
                    break;
            }
        }
        public void GetPurchaseItem(string userInput)
        {
            selectedItem = userInput;
        }
        public int DefineItemAmount()///need a exemption handle for the amount of items a user picks
        {
            Console.WriteLine("You have selected {0}", selectedItem);
            Console.WriteLine("How many {0} would you like to purchase", selectedItem);
            string userInput = Console.ReadLine();
            int.TryParse(userInput, out selectedAmount);
            return selectedAmount;
        }
        public void PurchaseItem()
        {
            if (selectedItem == "lemons") ///make a possible list of items and reference list rather than a string///
            {
                ///run inventory methods for subtracting and adding to list
            }
            else if (selectedItem == "cups")
            {

            }
            else if (selectedItem == "sugar cubes")
            {

            }
            else if(selectedItem =="ice cubes")
            {

            }
            else
            {

            }
            Console.WriteLine("You have chosen to purchase {0} {1}", selectedAmount , selectedItem);
            Console.WriteLine();
        }
        
    }
    
}
