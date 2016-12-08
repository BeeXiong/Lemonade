using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        private bool nuetralTaste;
        private bool sourTaste;
        private bool sweetTaste;
        private int lemonAmount;
        private int sugarAmount;
        private int iceCubeAmount;
        public Recipe()
        {

        }
        public void ChooseIngredients()
        {
            Console.WriteLine("Ok! lets pick your ingredient");
            Console.WriteLine("Lemons");
            Console.WriteLine("Ice Cubes");
            Console.WriteLine("Sugar Cubes");
            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "lemons":
                    SetLemonAmount();
                    break;
                case "ice cubes":
                    SetIceCubes();
                    break;
                case "sugar cubes":
                    SetSugarCubes();
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' ");
                    ChooseIngredients();
                    break;
            }
        }
        public void SetLemonAmount()
        {
            Console.WriteLine("How Many Lemons would you like to use? ");
            string lemonChoice = Console.ReadLine();
            lemonAmount = (Convert.ToInt16(lemonChoice));
        }
        public void VeryifyLemonAmount(decimal inventoryAmount)
        {
            if (GetLemonAmount() >= 11 || GetLemonAmount() > inventoryAmount && GetLemonAmount() < 1)
            {
                Console.WriteLine("Please check to make sure you have enough lemons and make sure you are using between 1 and 10 lemons");
                ChooseIngredients();
            }
        }
        public int GetLemonAmount()
        {
            return lemonAmount;
        }
        public void SetIceCubes()
        {
            Console.WriteLine("How Many Ice Cubes would you like to use? ");
            string iceCubeChoice = Console.ReadLine();
            iceCubeAmount = Convert.ToInt16(iceCubeChoice);
        }
        public void VeryifyIceCubeAmount(decimal inventoryAmount)
        {
            if (GetIceCubeAmount() >= 11 || GetIceCubeAmount() > inventoryAmount)
            {

                Console.WriteLine("Please check to make sure you have enough ice cubes and make sure you are using between 1 and 10 ice cubes");
                ChooseIngredients();
            }
        }
        public int GetIceCubeAmount()
        {
            return iceCubeAmount;
        }
        public void SetSugarCubes()
        {
            Console.WriteLine("How Many Sugar Cubes would you like to use? ");
            string sugarCubeChoice = Console.ReadLine();
            sugarAmount = Convert.ToInt16(sugarCubeChoice);
        }
        public void VeryifySugarAmount(decimal inventoryAmount)
        {
            if (GetSugarAmount() >= 11 || GetSugarAmount() > inventoryAmount)
            {
                Console.WriteLine("Please check to make sure you have enough sugar cubes and make sure you are using between 1 and 10 sugar cubes");
                ChooseIngredients();
            }
        }
        public int GetSugarAmount()
        {
            return sugarAmount;
        }
        public void SetTaste()
        {
            if (GetLemonAmount() >= GetSugarAmount())
            {
                decimal taste = (GetLemonAmount() / GetSugarAmount()) - (GetIceCubeAmount() / 5);
                if (taste >= 2)
                {
                    sourTaste = true;
                }
                else if (taste >= 0)
                {
                    nuetralTaste = true;
                }
            }
            else if (GetSugarAmount() >= GetLemonAmount())
            {
                decimal taste = (GetSugarAmount() / GetLemonAmount()) - (GetIceCubeAmount() / 5);
                if (taste >= 2)
                {
                    sweetTaste = true;
                }
                else if (taste >= 0)
                {
                    nuetralTaste = true;
                }
            }
        }
        public bool GetNuetralTaste()
        {
            return nuetralTaste;
        }
        public bool GetSweetTaste()
        {
            return sweetTaste;
        }

        public bool GetSourTaste()
        {
            return sourTaste;
        }
    }
}
    

