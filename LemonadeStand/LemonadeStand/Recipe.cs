using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Recipe
    {
        List<int> dailyCups = new List<int>();
        Lemon lemonInventory;
        SugarCubes sugarInventory;
        IceCube iceInventory;

        public Recipe()
        {
            this.lemonInventory = new Lemon();
            this.sugarInventory = new SugarCubes();
            this.iceInventory = new IceCube();
        }
        public void Display()
        {
        
        }


    }
    

}
