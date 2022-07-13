using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.modules
{
    class AreaItemMagnet
    {
        public void pickupAll(List<PickupItem_Networked> Objects, Network_Player localPlayer)
        {
            foreach (PickupItem_Networked Item in Objects)
            {
                Vector3 pivotPos1 = Item.PickupItem.transform.position;
                
                float distance = Vector3.Distance(pivotPos1, localPlayer.transform.position);

                if (distance <= 70f)
                {
                    Vector3 newPos = new Vector3(localPlayer.transform.position.x, localPlayer.transform.position.y + 10f, localPlayer.transform.position.z);
                    Item.transform.position = newPos;
                }
            }
        }
    }
}
