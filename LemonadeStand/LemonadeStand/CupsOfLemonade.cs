using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CupsOfLemonade
    {
        List<int> CupsForSale = new List<int>();
        Lemon lemonInventory;
        Cup cupInventory;
        Sugar sugarInventory;
        IceCube iceInventory;

        public CupsOfLemonade()
        {
            this.lemonInventory = new Lemon();
            this.cupInventory = new Cup();
            this.sugarInventory = new Sugar();
            this.iceInventory = new IceCube();
        }
        public void MakeCups()
        {

        }
        public void DetermineIngredient()
        {

        }
        public void SubtractIngredients()
        {

        }

    }

}
