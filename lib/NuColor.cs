using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.lib
{
    class NuColor
    {
        public static Color RGBtoColor(float r = 255f, float g = 255f, float b = 255f)
        {
            return new Color(r / 255f, g / 255f, b / 255f);
        }
        public static Color RGBAtoColor(float r = 255f, float g = 255f, float b = 255f, float a = 255f)
        {
            return new Color(r / 255f, g / 255f, b / 255f, a / 255f);
        }
    }
}
