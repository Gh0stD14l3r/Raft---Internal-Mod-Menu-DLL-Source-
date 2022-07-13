using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


namespace RaftHax
{
   
    class Hacks : MonoBehaviour
    {
        public static string m_Title = "Raft Mod Menu - Gh0st v1.1";

        public static bool t_MENU = true;
        public static bool t_ESP = false;
        public static bool t_CTRL = false;
        public static bool t_GOD = false;
        public static bool t_FLYRAFT = false;
        public static bool t_FLYSELF = false;
        public static bool t_HOTKEYS = false;
        public static bool t_PLAYERS = false;
        public static bool t_AIMBOT = false;

        public static bool toggleESP;
        public static bool toggleControl;
        public static bool toggleGod;
        public static bool toggleFlyingRaft;
        public static bool toggleFlyingSelf;
        public static bool toggleHotkeys;
        public static bool togglePlayers;
        public static bool toggleAimbot;


        public static float Timer = 0f;
        public static List<Network_Entity> NetworkEntities = new List<Network_Entity>();
        public static List<Network_Player> NetworkPlayers = new List<Network_Player>();
        public static List<PickupItem_Networked> ItemObjects = new List<PickupItem_Networked>();
        public static List<RaftBounds> Rafts = new List<RaftBounds>();

        public static Camera MainCamera = null;

        public static Network_Player localPlayer = null;
        public static Network_Entity localShark = null;
        public static Raft localRaft = null;
        
        public static float raft_driftSpeed = 0f;
        private static bool isLoaded = LoadSceneManager.IsGameSceneLoaded;

        private static modules.ESP mESP = new modules.ESP();
        private static modules.GodMode mGOD = new modules.GodMode();
        private static modules.ItemSpawner mSPAWNER = new modules.ItemSpawner();
        private static modules.AreaItemMagnet mAreaMagnet = new modules.AreaItemMagnet();
        private static modules.AimBot mAimbot = new modules.AimBot();

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
                t_MENU = !t_MENU;
            }
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                KillShark();
            }
            if (Input.GetKeyDown(KeyCode.Keypad2))
            {
                mAreaMagnet.pickupAll(ItemObjects, localPlayer);
            }
            if (Input.GetKeyDown(KeyCode.Keypad3))
            {
                ReviveAllPlayers();
            }
            if (Input.GetKeyDown(KeyCode.Keypad4))
            {
                t_FLYRAFT = !t_FLYRAFT;
            }
            if (Input.GetKeyDown(KeyCode.Keypad5))
            {
                t_GOD = !t_GOD;
            }
            if (Input.GetKeyDown(KeyCode.Keypad6))
            {
                TeleportToRaft();
            }
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                if (t_FLYRAFT && isLoaded)
                {
                    raftY += 0.5f;
                }
                if (t_FLYSELF && isLoaded)
                {
                    selfY += 0.5f;
                }
            }
            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                if (t_FLYRAFT && isLoaded)
                {
                    raftY -= 0.5f;
                }
                if (t_FLYSELF && isLoaded)
                {
                    selfY -= 0.5f;
                }
            }
            
            if (Input.GetKey(KeyCode.LeftShift) && t_AIMBOT)
            {
                //Aimbot only set to target the shark. You can add your own loop here to get specific
                //Entities or Players. Basic prediction has been setup as POC
                mAimbot.aim(localShark, localPlayer);
            }

            Timer += Time.deltaTime;
            if (Timer >= 5f && isLoaded) // how long you should wait between updates
            {
                Timer = 0f; 
                            
                MainCamera = Camera.main;

                NetworkEntities = UnityEngine.GameObject.FindObjectsOfType<Network_Entity>().ToList(); 
                NetworkPlayers = UnityEngine.GameObject.FindObjectsOfType<Network_Player>().ToList();
                ItemObjects = UnityEngine.GameObject.FindObjectsOfType<PickupItem_Networked>().ToList();
                Rafts = UnityEngine.GameObject.FindObjectsOfType<RaftBounds>().ToList();

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

            updateChecks();
        }

        public void OnGUI()
        {
            if (!isLoaded)
            {
                GUI.Box(new Rect(5f, 5f, 250f, 30f), "");
                GUI.Label(new Rect(10f, 5f, 250f, 30f), "\x57\x61\x69\x74\x69\x6e\x67\x20\x66\x6f\x72\x20\x67\x61\x6d\x65\x20\x74\x6f\x20\x6c\x6f\x61\x64");
            }
            
            if (t_MENU && isLoaded) //Menu after Insert has been pressed
            {
                GUI.Box(new Rect(5f, 5f, 250f, 95f), "");
                GUI.Label(new Rect(10f, 5f, 250f, 30f), m_Title);
                
                toggleESP = GUI.Toggle(new Rect(10f, 30f, 250f, 25f), t_ESP, "Enable/Disable ESP");
                if (toggleESP != t_ESP)
                {
                    t_ESP = !t_ESP;
                }
                toggleControl = GUI.Toggle(new Rect(10f, 55f, 250f, 25f), t_CTRL, "Control Panel");
                if (toggleControl != t_CTRL)
                {
                    t_CTRL = !t_CTRL;
                }
                toggleHotkeys = GUI.Toggle(new Rect(10f, 80f, 250f, 25f), t_HOTKEYS, "Display Hotkeys");
                if (toggleHotkeys != t_HOTKEYS)
                {
                    t_HOTKEYS = !t_HOTKEYS;
                }
            }
            if (t_CTRL && t_MENU && isLoaded)
            {
                GUI.Box(new Rect(5f, 100f, 300f, 300f), "");

                if (GUI.Button(new Rect(10f, 105f, 140f, 30f), "Kill Shark")) //Kill Shark
                {
                    KillShark();
                }
                if (GUI.Button(new Rect(155f, 105f, 140f, 30f), "Item Spawn")) //Item Spawner
                {
                    mSPAWNER.spawnItem("Plastic", 5, localPlayer);
                    mSPAWNER.spawnItem("Plank", 5, localPlayer);

                }
                if (GUI.Button(new Rect(10f, 140f, 140f, 30f), "Damage Shark")) // Damage Shark by 20
                {
                    localShark.Button_Damage();
                }
                if (GUI.Button(new Rect(155f, 140f, 140f, 30f), "Area Magnet")) // Teleport items in area to you
                {
                    mAreaMagnet.pickupAll(ItemObjects, localPlayer);
                }
                if (GUI.Button(new Rect(10f, 175f, 140f, 30f), "Revive Players")) //Revive All Players
                {
                    ReviveAllPlayers();
                    
                }
                if (GUI.Button(new Rect(155f, 175f, 140f, 30f), "")) //
                {
                    
                }
                if (GUI.Button(new Rect(10f, 210f, 140f, 30f), "Restore Stats")) //Fill your personal stats
                {
                    mGOD.enable(localPlayer);
                }
                if (GUI.Button(new Rect(10f, 245f, 140f, 30f), "Anchor Raft")) //Stop the raft
                {
                    if (localRaft != null)
                    {
                        if (raft_driftSpeed == 0f)
                        {
                            raft_driftSpeed = localRaft.waterDriftSpeed;
                        }
                        if (localRaft.waterDriftSpeed == 0f)
                        {
                            localRaft.waterDriftSpeed = raft_driftSpeed;
                        }
                        else
                        {
                            localRaft.waterDriftSpeed = 0f;
                        }
                    }
                }
                if (GUI.Button(new Rect(10f, 280f, 140f, 30f), "Teleport To Raft")) //Teleport To Raft
                {
                    TeleportToRaft();
                }
                toggleGod = GUI.Toggle(new Rect(10f, 315f, 140f, 25f), t_GOD, "GOD Mode"); //God Mode
                if (toggleGod != t_GOD)
                {
                    t_GOD = !t_GOD;
                }
                togglePlayers = GUI.Toggle(new Rect(155f, 315f, 140f, 25f), t_GOD, "View Players"); //Player Interaction
                if (togglePlayers != t_PLAYERS)
                {
                    t_PLAYERS = !t_PLAYERS;
                }
                toggleFlyingRaft = GUI.Toggle(new Rect(10f, 340f, 140f, 25f), t_FLYRAFT, "Flying Raft"); //Toggle Harry Potter raft
                if (toggleFlyingRaft != t_FLYRAFT)
                {
                    t_FLYRAFT = !t_FLYRAFT;
                }
                toggleAimbot = GUI.Toggle(new Rect(155f, 340f, 140f, 25f), t_AIMBOT, "Shark Aimbot"); //Toggle Aimbot
                if (toggleAimbot != t_AIMBOT)
                {
                    t_AIMBOT = !t_AIMBOT;
                }
                toggleFlyingSelf = GUI.Toggle(new Rect(10f, 365f, 140f, 25f), t_FLYSELF, "Localplayer Fly"); //Toggle flying person *** Quite Buggy ***
                if (toggleFlyingSelf != t_FLYSELF)
                {
                    t_FLYSELF = !t_FLYSELF;
                }
            }

            if (t_HOTKEYS && t_MENU && isLoaded)
            {
                GUI.Box(new Rect(260f, 5f, 900f, 25f), "");
                GUI.Label(new Rect(265f, 5f, 900f, 25f), "\x4b\x69\x6c\x6c\x20\x53\x68\x61\x72\x6b\x20\x5b\x4e\x75\x6d\x70\x61\x64\x31\x5d\x20\x2d\x20\x41\x72\x65\x61\x20\x4d\x61\x67\x6e\x65\x74\x20\x5b\x4e\x75\x6d\x70\x61\x64\x32\x5d\x20\x2d\x20\x52\x65\x76\x69\x76\x65\x20\x50\x6c\x61\x79\x65\x72\x73\x20\x5b\x4e\x75\x6d\x70\x61\x64\x33\x5d\x20\x2d\x20\x46\x6c\x79\x69\x6e\x67\x20\x52\x61\x66\x74\x20\x5b\x4e\x75\x6d\x70\x61\x64\x34\x5d\x20\x2d\x20\x47\x6f\x64\x20\x4d\x6f\x64\x65\x20\x5b\x4e\x75\x6d\x70\x61\x64\x35\x5d\x20\x2d\x20\x54\x50\x20\x54\x6f\x20\x52\x61\x66\x74\x20\x5b\x4e\x75\x6d\x70\x61\x64\x36\x5d");
            }

            performESP();
        } //

        private void performESP()
        {
            if (Event.current.type != EventType.Repaint) return;

            if (t_ESP && isLoaded)
            {
                foreach (RaftBounds Item in Rafts)
                {
                    mESP.raftesp(Item, Color.green, Item.name, localPlayer);
                }
                foreach (Network_Player Player in NetworkPlayers)
                {
                    mESP.esp(Player, Color.yellow, Player.Network.LocalSteamID.ToString(), localPlayer);
                }
                foreach (Network_Entity Entity in NetworkEntities)
                {
                    mESP.esp(Entity, Color.green, Entity.Network.PersonaName, localPlayer);
                }
                foreach (PickupItem_Networked Item in ItemObjects)
                {
                    mESP.esp(Item, Color.green, Item.PickupItem.PickupName, localPlayer);
                }

            }

            
        } //

        private void updateChecks()
        {
            if (t_GOD && isLoaded)
            {
                mGOD.enable(localPlayer);
            }
            if (t_FLYRAFT && isLoaded)
            {
                FlyRaft();
            }
            if (t_FLYSELF && isLoaded)
            {
                FlySelf();
            }
            if (t_AIMBOT)
            {

            }
        } //

        private void KillShark()
        {
            localShark.Button_Kill();
        }

        private void FlyRaft()
        {
            Vector3 raftFlyingPos = new Vector3(localRaft.transform.position.x, raftY, localRaft.transform.position.z);
            localRaft.transform.position = raftFlyingPos;
        }

        private void FlySelf()
        {
            Vector3 selfFlyingPos = new Vector3(localPlayer.transform.position.x, selfY, localPlayer.transform.position.z);
            localPlayer.transform.position = selfFlyingPos;
        }

        private void ReviveAllPlayers()
        {
            foreach (Network_Player Player in NetworkPlayers)
            {
                if (Player.Stats.IsDead || Convert.ToDouble(Player.Stats.stat_health) <= 0)
                {
                    Player.Revive();
                }
            }
        }

        private void TeleportToRaft()
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
