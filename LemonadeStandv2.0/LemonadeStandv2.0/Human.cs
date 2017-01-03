using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Human : Player
    {
        public string PlayerName { get; set; }
        public Human()
        {
            NamePlayers();
        }
        public void NamePlayers()
        {
            Console.WriteLine("Please enter the name for this Player");
            PlayerName = Console.ReadLine();
        }
    }
}
