using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.modules
{
    class ItemSpawner
    {
        private static List<Item_Base> Item_List = ItemManager.GetAllItems();
        
        public void spawnItem(String UniqueName, int Amount, Network_Player localPlayer)
        {
            //To be implemented
        }
    }
}
