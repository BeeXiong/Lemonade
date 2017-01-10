using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Customer
    {
        Random rndNumber;
        public string TastePreference{ get; private set; }
        public Customer(Random rnd)
        {
            rndNumber = rnd;
            SetTastePreference(rndNumber);
        }
        public void SetTastePreference(Random number)
        {
            int randomNumber;
            randomNumber = number.Next(20, 50);
            if (randomNumber <= 29)
            {
                TastePreference = "nuetral";
            }
            else if (randomNumber >= 30 && randomNumber <=39)
            {
                TastePreference = "sweet";
            }
            else if(randomNumber >= 40)
            {
                TastePreference = "sour";
            }
        }
    }
}
