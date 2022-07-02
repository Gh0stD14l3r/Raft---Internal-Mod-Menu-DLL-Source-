

using UnityEngine;

namespace RaftHax
{
    public class Loader
    {
        public static void init()
        {
            Loader.Load = new GameObject();
            Loader.Load.AddComponent<Hacks>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }

        public static void unload()
        {
            _unload();
        }

        private static void _unload()
        {
            GameObject.Destroy(Load);
        }
        
        private static GameObject Load;
    }
}
