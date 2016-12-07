using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public List<Lemon> gameLemons;
        public List<Cup> gameCups;
        public List<SugarCubes> gameSugar;
        public List<IceCube> gameIceCubes;
        public Lemon newLemon;
        public Cup newCup;
        public SugarCubes newSugarCube;
        public IceCube newIceCube;


        public Inventory()
        {
            gameLemons = new List<Lemon>();
            gameCups = new List<Cup>();
            gameSugar = new List<SugarCubes>();
            gameIceCubes = new List<IceCube>();
        }

        public void DisplayInventory()
        {
            Console.WriteLine("game lemons {0}",gameLemons.Count);
            Console.WriteLine("game Ice Cubes {0}", gameIceCubes.Count);
            Console.WriteLine("game Sugar {0}", gameSugar.Count);
            Console.WriteLine("game cups {0}", gameCups.Count);
        }

    }
}
