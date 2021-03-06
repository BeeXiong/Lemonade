﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        private bool nuetralTaste;
        private bool sourTaste;
        private bool sweetTaste;
        public int lemonAmount;
        public int sugarAmount;
        private int iceCubeAmount;
        private string itemSelection;
        public Recipe()
        {

        }
        public void ChooseIngredients()
        {
            Console.WriteLine("Ok! lets pick your ingredient");
            Console.WriteLine("Lemons");
            Console.WriteLine("Ice Cubes");
            Console.WriteLine("Sugar Cubes");
            string userfeedback = Console.ReadLine().ToLower();
            switch (userfeedback)
            {
                case "lemons":
                    SetLemonAmount();
                    SetItemSelection(userfeedback);
                    
                    break;
                case "ice cubes":
                    SetIceCubes();
                    SetItemSelection(userfeedback);
                    
                    break;
                case "sugar cubes":
                    SetSugarCubes();
                    SetItemSelection(userfeedback);
                    
                    break;
                default:
                    Console.WriteLine("Invaild Entry. Please select either 'Lemons' - 'Ice Cubes' - 'Sugar Cubes' ");
                    ChooseIngredients();
                    break;
            }
        }
        public void DisplaySelectedIngredients()
        {
            Console.WriteLine("Okay. Here are the ingredients you picked so far.");
            Console.WriteLine("Lemons {0}", GetLemonAmount());
            Console.WriteLine("Sugar Cubes {0}", GetSugarAmount());
            Console.WriteLine("Ice Cubes {0}", GetIceCubeAmount());
        }
        public void SetItemSelection(string userInput)
        {
            itemSelection = userInput;
        }
        public string GetItemSelection()
        {
            return itemSelection;
        }
        public void SetLemonAmount()
        {
            Console.WriteLine("How Many Lemons would you like to use? ");
            string lemonChoice = Console.ReadLine();
            lemonAmount = (Convert.ToInt16(lemonChoice));
        }
        public bool VeryifyLemonAmount(decimal inventoryAmount)
        {
            if (GetLemonAmount() <= 11 && GetLemonAmount() < inventoryAmount && GetLemonAmount() > 1)
            {
                return true;
            }
            else
            {
                Console.WriteLine("Please check to make sure you have enough lemons and make sure you are using between 1 and 10 lemons");
                return false;
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
    

