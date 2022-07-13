using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.modules
{
    class AimBot
    {
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private static float arrowVelocity;
        public void aim(Network_Entity Entity, Network_Player localPlayer)
        {
            Vector3 targetPosition = Entity.transform.position;
            float distance = Vector3.Distance(targetPosition, localPlayer.transform.position);
            arrowVelocity = distance * 1.5f;

            Vector3 targetPrediction = Entity.transform.position + (Entity.transform.forward * (distance / 2f / 2f));
            Vector3 w2sPrediction = Camera.main.WorldToScreenPoint(targetPrediction);

            if (w2sPrediction.z >= 0 && !Entity.IsDead) //Remove the z-axis check if you want to spin bot the shit out of it
            {
                aim_payload(new Vector2(w2sPrediction.x, (float)Screen.height - w2sPrediction.y - arrowVelocity));
            }
            
        }

        public void aim_payload(Vector2 point)
        {
            double DistX = ( point.x - Screen.width / 2.0f ) / 2;
            double DistY = ( point.y - Screen.height / 2.0f ) / 2;

            mouse_event(0x0001, (int)DistX, (int)DistY, 0, 0);
        }
    }
}
