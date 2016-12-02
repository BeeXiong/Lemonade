using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class CupsOfLemonade
    {
        private double salePrice;
        HumanPlayer firstplayer;

        public CupsOfLemonade(double salePrice)
        {
            this.salePrice = salePrice;
            firstplayer = new HumanPlayer();
        }
        public void GenerateSalePrice()
        {

        }
        public void GenerateSalesAmount()
        {

        }

        public void AddSalesToBank()
        {
            
        }
        public void GetPlayerSales(double totalSales)
        {
            totalSales = firstplayer.playerBank;
        }
    }

}
