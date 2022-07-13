using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.objects
{
    class oRaft
    {
        public static Vector3 position;
        public static Vector3 bBottomLeft;
        public static Vector3 bBottomRight;
        public static Vector3 bTopLeft;
        public static Vector3 bTopRight;




        public void setPosition(Vector3 position)
        {
            oRaft.position = position;
        }

        public static Vector3 getPosition()
        {
            return oRaft.position;
        }

    }
}
