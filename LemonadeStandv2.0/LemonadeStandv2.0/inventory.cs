using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Inventory
    {
        public List<Lemon> gameLemons;
        public List<LemonadeCup> gameLemonadeCups;
        public List<SugarCube> gameSugarCubes;
        public List<IceCube> gameIceCubes;
        public List<Cup> gameCups;
        public Inventory()
        {
            gameLemons = new List<Lemon>();
            gameLemonadeCups = new List<LemonadeCup>();
            gameSugarCubes = new List<SugarCube>();
            gameIceCubes = new List<IceCube>();
            gameCups = new List<Cup>();
        }
    }
    

}
