using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        Lemon lemonInventory;
        Cup cupInventory;
        SugarCubes sugarInventory;
        IceCube iceInventory;
        Store storePurchase;

        public Inventory()
        {
            this.lemonInventory = new Lemon();
            this.cupInventory = new Cup();
            this.sugarInventory = new SugarCubes();
            this.iceInventory = new IceCube();
            this.storePurchase = new Store();
        }
        public void subtractInventory()
        {
            for (int index = 0; index < storePurchase.selectedAmount; index++ ) 
            {
                lemonInventory.gameLemons.RemoveAt(0);
            }
        }
        public void addInventory()
        {
            for (int index = 0; index < storePurchase.selectedAmount; index++)
            {
                lemonInventory.gameLemons.Last();
            }
        }
        public void DisplayInventory()
        {

        }
    }
}
