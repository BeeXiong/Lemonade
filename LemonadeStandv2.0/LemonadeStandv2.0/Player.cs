﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandv2._0
{
    class Player
    {
        public string playerName { get; set;  }
        Wallet playerWallet;
        Inventory gameInventory;
        public Player()
        {
            playerWallet = new Wallet();
            gameInventory = new Inventory();
        }

    }
}