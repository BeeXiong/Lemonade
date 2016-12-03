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
        Sugar sugarInventory;
        IceCube iceInventory;

        public Inventory()
        {
            this.lemonInventory = new Lemon();
            this.cupInventory = new Cup();
            this.sugarInventory = new Sugar();
            this.iceInventory = new IceCube();
        }
        public void CalculateInventory()
        {

        }
        public void DisplayInventory()
        {

        }
    }
}
