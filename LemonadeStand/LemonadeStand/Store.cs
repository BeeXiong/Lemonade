using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Store
    {
        HumanPlayer firstPlayer;
        Lemon lemonInventory;
        Cup cupInventory;
        Sugar sugarInventory;
        IceCube iceInventory;

        public Store(HumanPlayer firstPlayer)
        {
            this.firstPlayer = firstPlayer;
            this.lemonInventory = new Lemon();
            this.cupInventory = new Cup();
            this.sugarInventory = new Sugar();
            this.iceInventory = new IceCube();
        }
        public void PurchaseItem()
        {
            
        }
        public void IdentifyItem()
        {

        }
    }
}
