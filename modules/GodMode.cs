using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftHax.modules
{
    class GodMode
    {
        public static void enable (Network_Player localPlayer)
        {
            if (localPlayer.Stats.stat_health.Value != localPlayer.Stats.stat_health.Max)
            {
                localPlayer.Stats.stat_health.SetToMaxValue();
            }
            if (localPlayer.Stats.stat_oxygen.Value != localPlayer.Stats.stat_oxygen.Max)
            {
                localPlayer.Stats.stat_oxygen.SetToMaxValue();
            }
            if (localPlayer.Stats.stat_hunger.Normal.Value != localPlayer.Stats.stat_hunger.Normal.Max)
            {
                localPlayer.Stats.stat_hunger.Consume(1000f, 0f, false);
            }
            if (localPlayer.Stats.stat_thirst.Normal.Value != localPlayer.Stats.stat_thirst.Normal.Max)
            {
                localPlayer.Stats.stat_thirst.Consume(1000f, 0f, false);
            }
        }
    }
}
