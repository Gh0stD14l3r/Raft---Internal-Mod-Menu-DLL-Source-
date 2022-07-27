using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.lib
{
    class CameraView
    {
        public static Texture2D GetTextureFromCamera(Camera mCamera)
        {
            Rect rect = new Rect(0, 0, mCamera.pixelWidth, mCamera.pixelHeight);
            RenderTexture renderTexture = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24);
            Texture2D screenShot = new Texture2D(mCamera.pixelWidth, mCamera.pixelHeight, TextureFormat.RGBA32, false);

            mCamera.targetTexture = renderTexture;
            mCamera.Render();

            RenderTexture.active = renderTexture;

            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();


            mCamera.targetTexture = null;
            RenderTexture.active = null;
            return screenShot;
        }
    }
}
