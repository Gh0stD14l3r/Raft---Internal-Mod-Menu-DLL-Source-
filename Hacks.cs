using System;
using System.Threading;
using UnityEngine;


namespace RaftHax
{
    class Hacks : MonoBehaviour
    {
        public static string m_Title = "Raft Mod Menu - Gh0st v1";

        public static bool t_MENU = true;
        public static bool t_ESP = false;
        public static bool t_CTRL = false;
        public static bool t_GOD = false;

        public static bool toggleESP;
        public static bool toggleControl;
        public static bool toggleGod;

        public static Network_Player localPlayer = null;
        public static Network_Entity localShark = null;
        public static Raft localRaft = null;
        

        public static float raft_driftSpeed = 0f;

        public void Start()
        {

        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.End)) //Kill hacks on "End" key pressed
            {
                Loader.unload();
            }
            if (Input.GetKeyDown(KeyCode.Insert))
            {
                t_MENU = !t_MENU;
            }

        }

        public void OnGUI()
        {
            if (t_MENU) //Menu after Insert has been pressed
            {
                GUI.Box(new Rect(5f, 5f, 300f, 90f), "");
                GUI.Label(new Rect(10f, 5f, 290f, 30f), m_Title);
                toggleESP = GUI.Toggle(new Rect(10f, 30f, 290f, 25f), t_ESP, "Enable/Disable ESP");
                if (toggleESP != t_ESP)
                {
                    t_ESP = !t_ESP;
                }
                toggleControl = GUI.Toggle(new Rect(10f, 55f, 290f, 25f), t_CTRL, "Control Panel");
                if (toggleControl != t_CTRL)
                {
                    t_CTRL = !t_CTRL;
                }

                if (localPlayer == null)
                {
                    foreach (Network_Player Player in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Player)) as Network_Player[])
                    {
                        if (Player.IsLocalPlayer)
                        {
                            localPlayer = Player;
                        }
                    }
                }
                if (localShark == null)
                {
                    foreach (Network_Entity Entity in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Entity)) as Network_Entity[])
                    {
                        if (Entity.name.Contains("AI_Shark"))
                        {
                            localShark = Entity;
                        }
                    }
                }
                if (localRaft == null)
                {
                    foreach (Raft Entity in UnityEngine.GameObject.FindObjectsOfType(typeof(Raft)) as Raft[])
                    {
                        if (Entity.isActiveAndEnabled)
                        {
                            localRaft = Entity;
                        }
                    }
                }
            }
            

            if (t_CTRL && t_MENU)
            {
                GUI.Box(new Rect(5f, 100f, 300f, 300f), "");

                if (GUI.Button(new Rect(10f, 105f, 140f, 30f), "Kill Shark")) //Kill Shark
                {
                    foreach (Network_Entity Shark_Entity in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Entity)) as Network_Entity[])
                    {
                        if (Shark_Entity.name.Contains("Shark"))
                        {
                            Shark_Entity.Button_Kill();
                        }
                        
                    }
                }
                if (GUI.Button(new Rect(10f, 140f, 140f, 30f), "Damage Shark")) // Damage Shark by 20
                {
                    foreach (Network_Entity Shark_Entity in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Entity)) as Network_Entity[])
                    {
                        if (Shark_Entity.name.Contains("Shark"))
                        {
                            Shark_Entity.Button_Damage();
                        }
                    }
                }
                if (GUI.Button(new Rect(10f, 175f, 140f, 30f), "Revive Players")) //Revive All Players
                {
                    foreach (Network_Player Player in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Player)) as Network_Player[])
                    {
                        if (Player.Stats.IsDead || Convert.ToDouble(Player.Stats.stat_health) <= 0)
                        {
                            Player.Revive();
                        }
                    }
                }
                if (GUI.Button(new Rect(10f, 210f, 140f, 30f), "Restore Stats")) //Fill your personal stats
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
                    if (localRaft != null && localPlayer != null)
                    {
                        Vector3 raftPos = localRaft.transform.position;
                        localPlayer.transform.position = raftPos;
                    }
                }
                toggleGod = GUI.Toggle(new Rect(10f, 315f, 250f, 25f), t_GOD, "Keep Max Stats (GOD Mode)"); //God Mode
                if (toggleGod != t_GOD)
                {
                    t_GOD = !t_GOD;
                }

            }
            
            if (t_GOD)
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

            if (t_ESP)
            {
                foreach (Network_Player Player in UnityEngine.GameObject.FindObjectsOfType(typeof(Network_Player)) as Network_Player[])
                {
                    Vector3 pivotPos1 = Player.transform.position;
                    Vector3 playerFootPos1; playerFootPos1.x = pivotPos1.x; playerFootPos1.z = pivotPos1.z; playerFootPos1.y = pivotPos1.y - 2f;
                    Vector3 playerHeadPos1; playerHeadPos1.x = playerFootPos1.x; playerHeadPos1.z = playerFootPos1.z; playerHeadPos1.y = playerFootPos1.y + 4f;

                    Vector3 w2s_playerFoot1 = Camera.main.WorldToScreenPoint(playerFootPos1);
                    Vector3 w2s_playerHead1 = Camera.main.WorldToScreenPoint(playerHeadPos1);
                    
                    if (w2s_playerFoot1.z > 0f)
                    {
                        DrawESP(w2s_playerFoot1, w2s_playerHead1, Color.green, Player.name, Player.Stats.stat_health.Value.ToString());
                    }
                }
                
                Vector3 pivotPos = localShark.transform.position;
                Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f;
                Vector3 playerHeadPos; playerHeadPos.x = playerFootPos.x; playerHeadPos.z = playerFootPos.z; playerHeadPos.y = playerFootPos.y + 2f;

                Vector3 w2s_playerFoot = Camera.main.WorldToScreenPoint(playerFootPos);
                Vector3 w2s_playerHead = Camera.main.WorldToScreenPoint(playerHeadPos);

                if (w2s_playerFoot.z > 0f && !localShark.name.Contains("Player"))
                {
                    if (localShark.IsDead)
                    {
                        DrawESP(w2s_playerFoot, w2s_playerHead, Color.red, localShark.name, localShark.stat_health.Value.ToString());
                    }
                    else
                    {
                        DrawESP(w2s_playerFoot, w2s_playerHead, Color.yellow, localShark.name, localShark.stat_health.Value.ToString());
                    }
                }

                Vector3 pivotPos4 = localRaft.transform.position;
                Vector3 playerFootPos4; playerFootPos4.x = pivotPos4.x; playerFootPos4.z = pivotPos4.z; playerFootPos4.y = pivotPos4.y - 2f;
                Vector3 playerHeadPos4; playerHeadPos4.x = playerFootPos4.x; playerHeadPos4.z = playerFootPos4.z; playerHeadPos4.y = playerFootPos4.y + 2f;

                Vector3 w2s_playerFoot4 = Camera.main.WorldToScreenPoint(playerFootPos4);
                Vector3 w2s_playerHead4 = Camera.main.WorldToScreenPoint(playerHeadPos4);

                if (w2s_playerFoot4.z > 0f && !localShark.name.Contains("Player"))
                {
                    DrawESP(w2s_playerFoot4, w2s_playerHead4, Color.magenta, localRaft.name, "0");
                }

            }
            
        }

        public void DrawESP(Vector3 objfootPos, Vector3 objheadPos, Color objColor, String name, String health)
        {
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawBox(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height, objColor, 2f);
            Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height), $"{name} [{health}]");

        }

    }
}
