using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public List<Lemon> gameLemons;
        public List<Cup> gameCups;
        public List<SugarCubes> gameSugarCubes;
        public List<IceCube> gameIceCubes;
        public List<LemonadeCup> sourLemonadeCups;
        public List<LemonadeCup> SweetLemonadeCups;
        public List<LemonadeCup> NuetralLemonadeCups;
        public Lemon newLemon;
        public Cup newCup;
        public SugarCubes newSugarCube;
        public IceCube newIceCube;
        public LemonadeCup newSourLemonadeCup;
        public LemonadeCup newSweetLemonadeCup;
        public LemonadeCup newNuetralLemonadeCup;
        private decimal lemonQuantity;
        private decimal iceCubeQuantity;
        private decimal sugarCubeQuantity;
        private decimal cupQuantity;
       
        public Inventory()
        {
            gameLemons = new List<Lemon>();
            gameCups = new List<Cup>();
            gameSugarCubes = new List<SugarCubes>();
            gameIceCubes = new List<IceCube>();
            sourLemonadeCups = new List<LemonadeCup>();
            SweetLemonadeCups = new List<LemonadeCup>();
            NuetralLemonadeCups = new List<LemonadeCup>();
        }
        public void DisplayInventory()
        {
            Console.WriteLine("game lemons {0}",gameLemons.Count);
            Console.WriteLine("game Ice Cubes {0}", gameIceCubes.Count);
            Console.WriteLine("game Sugar {0}", gameSugarCubes.Count);
            Console.WriteLine("game cups {0}", gameCups.Count);
        }
        public void ReviewLemonQuanity()
        {
            lemonQuantity = gameLemons.Count;
        }
        public decimal GetLemonQuantity()
        {
            return lemonQuantity;
        }
        public void ReviewIceCubeQuanity()
        {
            iceCubeQuantity = gameIceCubes.Count;
        }
        public decimal GetIceCubeQuantity()
        {
            return iceCubeQuantity;
        }
        public void ReviewSugarCubeQuanity()
        {
            sugarCubeQuantity = gameSugarCubes.Count;
        }
        public decimal GetSugarCubeQuantity()
        {
            return sugarCubeQuantity;
        }
        public void ReviewCupQuantity()
        {
            cupQuantity = gameCups.Count;
        }
        public decimal GetCupQuantity()
        {
            return cupQuantity;
        }
    }
}
