using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


namespace RaftHax
{
   
    class Hacks : MonoBehaviour
    {
        public static float Timer = 4f;
        public static List<Network_Entity> NetworkEntities = new List<Network_Entity>();
        public static List<Network_Player> NetworkPlayers = new List<Network_Player>();
        public static List<PickupItem_Networked> ItemObjects = new List<PickupItem_Networked>();
        public static List<PickupItem_Networked> ItemMagnet = new List<PickupItem_Networked>();
        public static List<RaftBounds> Rafts = new List<RaftBounds>();
        public static List<Bed> Beds = new List<Bed>();

        public static Camera MainCamera = null;

        public static Network_Player localPlayer = null;
        public static Network_Entity localShark = null;
        public static Raft localRaft = null;
        
        public static float raft_driftSpeed = 0f;
        private static bool isLoaded = LoadSceneManager.IsGameSceneLoaded;

        private static float raftY = 10f, selfY = 10f;
        private static Network_Entity closest_entity;

        public void Start()
        {
            
        }

        public void Update()
        {
            if (isLoaded != LoadSceneManager.IsGameSceneLoaded)
            {
                isLoaded = !isLoaded;
            }
            
            if (Input.GetKeyDown(KeyCode.End)) //Kill hacks on "End" key pressed
            {
                Loader.unload();
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                modules.UI.t_MENU = !modules.UI.t_MENU;
            }
           
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                if (modules.UI.t_FLYRAFT && isLoaded)
                {
                    raftY += 0.5f;
                }
                if (modules.UI.t_FLYSELF && isLoaded)
                {
                    selfY += 0.5f;
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                if (modules.UI.t_FLYRAFT && isLoaded)
                {
                    raftY -= 0.5f;
                }
                if (modules.UI.t_FLYSELF && isLoaded)
                {
                    selfY -= 0.5f;
                }
            }
            

            Timer += Time.deltaTime;
            if (Timer >= 5f && isLoaded) // how long you should wait between updates
            {
                Timer = 0f; 
                            
                MainCamera = Camera.main;

                NetworkEntities = UnityEngine.GameObject.FindObjectsOfType<Network_Entity>().ToList(); 
                NetworkPlayers = UnityEngine.GameObject.FindObjectsOfType<Network_Player>().ToList();
                ItemObjects = UnityEngine.GameObject.FindObjectsOfType<PickupItem_Networked>().ToList();
                ItemMagnet = UnityEngine.GameObject.FindObjectsOfType<PickupItem_Networked>().ToList();
                Rafts = UnityEngine.GameObject.FindObjectsOfType<RaftBounds>().ToList();
                Beds = UnityEngine.GameObject.FindObjectsOfType<Bed>().ToList();


                foreach (Network_Player Player in NetworkPlayers)
                {
                    if (Player.IsLocalPlayer) localPlayer = Player;
                    
                }
                foreach (Network_Entity Entity in NetworkEntities)
                {
                    if (Entity.name.Contains("Shark")) localShark = Entity;
                }

                localRaft = UnityEngine.GameObject.FindObjectOfType<Raft>();
                
            }

            modules.SpeedHack.speedHack();
            updateChecks();
        }

        public void OnGUI()
        {
            if (!isLoaded)
            {
                GUI.Box(new Rect(5f, 5f, 250f, 30f), "");
                GUI.Label(new Rect(10f, 5f, 250f, 30f), "\x57\x61\x69\x74\x69\x6e\x67\x20\x66\x6f\x72\x20\x67\x61\x6d\x65\x20\x74\x6f\x20\x6c\x6f\x61\x64");
                return;
            }
            
            if (modules.UI.t_MENU) //Menu after Insert has been pressed
            {
                modules.UI.MainMenu = GUI.Window(0, modules.UI.MainMenu, modules.UI.MainWindow, "\x52\x61\x66\x74\x20\x4d\x6f\x64\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");
            }
            if (modules.UI.t_CTRL && modules.UI.t_MENU)
            {
                modules.UI.ControlMenu = GUI.Window(1, modules.UI.ControlMenu, modules.UI.ControlWindow, "\x52\x61\x66\x74\x20\x43\x6f\x6e\x74\x72\x6f\x6c\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");
            }
            if (modules.UI.t_ESP && modules.UI.t_MENU)
            {
                modules.UI.ESPMenu = GUI.Window(2, modules.UI.ESPMenu, modules.UI.ESPWindow, "\x52\x61\x66\x74\x20\x45\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");
            }
            if (modules.UI.t_SpawnMenu && modules.UI.t_MENU)
            {
                modules.UI.SpawnMenu = GUI.Window(3, modules.UI.SpawnMenu, modules.UI.ItemSpawnWindow, "\x52\x61\x66\x74\x20\x53\x70\x61\x77\x6e\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");
            }
            if (modules.UI.t_PlayerMenu && modules.UI.t_MENU)
            {
                modules.UI.PlayersMenu = GUI.Window(4, modules.UI.PlayersMenu, modules.UI.PlayersWindow, "\x52\x61\x66\x74\x20\x50\x6c\x61\x79\x65\x72\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");

            }
            if (modules.UI.t_SpeedHack && modules.UI.t_MENU)
            {
                modules.UI.SpeedHackMenu = GUI.Window(5, modules.UI.SpeedHackMenu, modules.UI.SpeedHackWindow, "\x52\x61\x66\x74\x20\x53\x70\x65\x65\x64\x48\x61\x63\x6b\x20\x4d\x65\x6e\x75\x20\x2d\x20\x47\x68\x30\x73\x74\x20\x76\x32\x2e\x30");
            }
            

            performESP();
        } //

        private void performESP()
        {
            if (modules.UI.t_ESP)
            {
                if (modules.UI.t_RaftESP)
                {
                    foreach (RaftBounds Item in Rafts)
                    {
                        modules.ESP.raftesp(Item, Color.green, Item.name, localPlayer);
                    }
                }
                
                if (modules.UI.t_EntityESP)
                {
                    foreach (Network_Entity Entity in NetworkEntities)
                    {
                        modules.ESP.netesp(Entity, Color.green, Entity.Network.PersonaName, localPlayer);
                    }
                }
                if (modules.UI.t_PlayerESP)
                {
                    foreach (Network_Player Player in NetworkPlayers)
                    {
                        if (Player.IsLocalPlayer != true)
                        {
                            modules.ESP.esp(Player, Color.yellow, Player.Network.LocalSteamID.ToString(), localPlayer);
                        }
                        
                    }
                }
                if (modules.UI.t_ItemESP)
                {
                    foreach (PickupItem_Networked Item in ItemObjects)
                    {
                        modules.ESP.itemesp(Item, Color.green, Item.PickupItem.PickupName, localPlayer);
                    }
                }
            }

            
        } //

        private void updateChecks()
        {
            if (modules.UI.t_GOD && isLoaded)
            {
                modules.GodMode.enable(localPlayer);
            }
            if (modules.UI.t_FLYRAFT && isLoaded)
            {
                FlyRaft();
            }
            if (modules.UI.t_FLYSELF && isLoaded)
            {
                FlySelf();
            }
            if (modules.UI.t_AIMBOT)
            {

            }
        } //

        public static void KillShark()
        {
            localShark.Button_Kill();
        }

        public static void FlyRaft()
        {
            Vector3 raftFlyingPos = new Vector3(localRaft.transform.position.x, raftY, localRaft.transform.position.z);
            localRaft.transform.position = raftFlyingPos;
        }

        public static void FlySelf()
        {
            Vector3 selfFlyingPos = new Vector3(localPlayer.transform.position.x, selfY, localPlayer.transform.position.z);
            localPlayer.transform.position = selfFlyingPos;
        }

        public static void ReviveAllPlayers()
        {
            foreach (Network_Player Player in NetworkPlayers)
            {
                if (Player.Stats.IsDead || Convert.ToDouble(Player.Stats.stat_health) <= 0)
                {
                    Player.Revive();
                }
            }
        }

        public static void TeleportToRaft()
        {
            if (localRaft != null && localPlayer != null)
            {
                Vector3 raftPos = localRaft.transform.position;
                Vector3 newPos = new Vector3(raftPos.x, raftPos.y + 10f, raftPos.z);
                localPlayer.transform.position = newPos;
            }
        }

    }
}
