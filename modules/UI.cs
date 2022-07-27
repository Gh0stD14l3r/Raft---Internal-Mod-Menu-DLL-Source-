using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.modules
{
    class UI
    {
        public static Rect MainMenu = new Rect(5, 5, 280, 110);
        public static Rect ESPMenu = new Rect(300, 5, 280, 188);
        public static Rect ControlMenu = new Rect(300, 5, 280, 150);
        public static Rect SpawnMenu = new Rect(300, 5, 400, 420);
        public static Rect PlayersMenu = new Rect(300, 5, 273, 316);
        public static Rect SpeedHackMenu = new Rect(300, 5, 250, 194);

        public static bool t_RaftESP = false;
        public static bool t_PlayerESP = false;
        public static bool t_EntityESP = false;
        public static bool t_ItemESP = false;

        public static bool t_DrawLabels = false;
        public static bool t_DrawBox = false;
        public static bool t_DrawLines = false;
        public static bool t_DrawSkeleton = false;
        public static bool t_DistanceFade = false;
        public static bool t_PlayerMenu = false;

        public static bool t_SpeedWalking = false;
        public static bool t_SpeedSprinting = false;
        public static bool t_SpeedSwimming = false;
        public static bool t_JumpHigh = false;

        public static bool toggleSpeedWalking;
        public static bool toggleSpeedSprinting;
        public static bool toggleSpeedSwimming;
        public static bool toggleJumpHigh;

        public static bool toggleRaftESP;
        public static bool togglePlayerESP;
        public static bool toggleEntityESP;
        public static bool toggleItemESP;

        public static bool toggleDrawLabels;
        public static bool toggleDrawBox;
        public static bool toggleDrawLines;
        public static bool toggleDrawSkeleton;
        public static bool toggleDistanceFade;
        public static bool togglePlayerMenu;

        public static bool t_MENU = true;
        public static bool t_ESP = false;
        public static bool t_CTRL = false;
        public static bool t_GOD = false;
        public static bool t_FLYRAFT = false;
        public static bool t_FLYSELF = false;
        public static bool t_HOTKEYS = false;
        public static bool t_PLAYERS = false;
        public static bool t_AIMBOT = false;
        public static bool t_SpeedHack = false;

        public static bool toggleESP;
        public static bool toggleControl;
        public static bool toggleGod;
        public static bool toggleFlyingRaft;
        public static bool toggleFlyingSelf;
        public static bool toggleHotkeys;
        public static bool togglePlayers;
        public static bool toggleAimbot;
        public static bool toggleSpeedHack;

        public static bool toggleSpawnMenu;
        public static bool t_SpawnMenu = false;

        public static float esp_slider_distance = 50f;
        private static string unique_name = "";
        private static string item_amount = "1";

        public static int currentPlayer = 0;
        public static float speedMultiplier = 5f;

        public static float currentWalkingSpeed = 0f;
        public static float currentSprintingSpeed = 0f;
        public static float currentSwimmingSpeed = 0f;
        public static float currentJumpHeight = 0f;


        public static void MainWindow(int windowID)
        {
            modules.UI.toggleESP = GUI.Toggle(new Rect(10f, 20f, 140f, 18f), modules.UI.t_ESP, "Enable/Disable ESP");
            if (modules.UI.toggleESP != modules.UI.t_ESP)
            {
                modules.UI.t_ESP = !modules.UI.t_ESP;
            }
            modules.UI.toggleControl = GUI.Toggle(new Rect(10f, 40f, 110f, 18f), modules.UI.t_CTRL, "Control Panel");
            if (modules.UI.toggleControl != modules.UI.t_CTRL)
            {
                modules.UI.t_CTRL = !modules.UI.t_CTRL;
            }
            modules.UI.toggleSpawnMenu = GUI.Toggle(new Rect(150f, 40f, 110f, 18f), modules.UI.t_SpawnMenu, "Spawn Menu");
            if (modules.UI.toggleSpawnMenu != modules.UI.t_SpawnMenu)
            {
                modules.UI.t_SpawnMenu = !modules.UI.t_SpawnMenu;
            }
            modules.UI.toggleSpeedHack = GUI.Toggle(new Rect(10f, 60f, 110f, 18f), modules.UI.t_SpeedHack, "SpeedHack Menu");
            if (modules.UI.toggleSpeedHack != modules.UI.t_SpeedHack)
            {
                modules.UI.t_SpeedHack = !modules.UI.t_SpeedHack;
            }
            modules.UI.togglePlayerMenu = GUI.Toggle(new Rect(150f, 60f, 110f, 18f), modules.UI.t_PlayerMenu, "Player Menu");
            if (modules.UI.togglePlayerMenu != modules.UI.t_PlayerMenu)
            {
                modules.UI.t_PlayerMenu = !modules.UI.t_PlayerMenu;
            }

            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

        public static void ESPWindow(int windowID)
        {
            toggleRaftESP = GUI.Toggle(new Rect(10f, 20f, 110f, 18f), t_RaftESP, "Raft ESP");
            if (toggleRaftESP != t_RaftESP)
            {
                t_RaftESP = !t_RaftESP;
            }
            togglePlayerESP = GUI.Toggle(new Rect(10f, 43f, 110f, 18f), t_PlayerESP, "Players ESP");
            if (togglePlayerESP != t_PlayerESP)
            {
                t_PlayerESP = !t_PlayerESP;
            }
            toggleEntityESP = GUI.Toggle(new Rect(10f, 66f, 110f, 18f), t_EntityESP, "Entity ESP");
            if (toggleEntityESP != t_EntityESP)
            {
                t_EntityESP = !t_EntityESP;
            }
            toggleItemESP = GUI.Toggle(new Rect(10f, 89f, 110f, 18f), t_ItemESP, "PickupItem ESP");
            if (toggleItemESP != t_ItemESP)
            {
                t_ItemESP = !t_ItemESP;
            }

            toggleDrawLabels = GUI.Toggle(new Rect(141f, 20f, 110f, 18f), t_DrawLabels, "Draw Labels");
            if (toggleDrawLabels != t_DrawLabels)
            {
                t_DrawLabels = !t_DrawLabels;
            }
            toggleDrawBox = GUI.Toggle(new Rect(141f, 43f, 110f, 18f), t_DrawBox, "Draw Box (ex Items)");
            if (toggleDrawBox != t_DrawBox)
            {
                t_DrawBox = !t_DrawBox;
            }
            toggleDrawLines = GUI.Toggle(new Rect(141f, 66f, 110f, 18f), t_DrawLines, "Draw Lines");
            if (toggleDrawLines != t_DrawLines)
            {
                t_DrawLines = !t_DrawLines;
            }
            toggleDrawSkeleton = GUI.Toggle(new Rect(141f, 89f, 110f, 18f), t_DrawSkeleton, "Player Skeleton");
            if (toggleDrawSkeleton != t_DrawSkeleton)
            {
                t_DrawSkeleton = !t_DrawSkeleton;
            }

            GUI.Label(new Rect(10f, 111f, 154f, 25f), "ESP Distance");

            float esp_set_dist = GUI.HorizontalSlider(new Rect(10f, 132f, 154f, 20f), esp_slider_distance, 30f, 1000f);
            if (esp_set_dist  != esp_slider_distance)
            {
                esp_slider_distance = esp_set_dist;
            }

            toggleDistanceFade = GUI.Toggle(new Rect(10f, 157f, 220f, 18f), t_DistanceFade, "ESP Fades with Distance");
            if (toggleDistanceFade != t_DistanceFade)
            {
                t_DistanceFade = !t_DistanceFade;
            }

            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

        public static void ControlWindow(int windowID)
        {
            if (GUI.Button(new Rect(10f, 20f, 117f, 20f), "Kill Shark")) 
            {
                Hacks.KillShark();
            }
            if (GUI.Button(new Rect(139f, 20f, 117f, 20f), "Damage Shark")) 
            {
                Hacks.localShark.Button_Damage();
            }
            if (GUI.Button(new Rect(10f, 45f, 117f, 20f), "Revive Players")) 
            {
                Hacks.ReviveAllPlayers();
            }
            if (GUI.Button(new Rect(10f, 70f, 117f, 20f), "Restore Stats")) 
            {
                modules.GodMode.enable(Hacks.localPlayer);
            }
            if (GUI.Button(new Rect(10f, 95f, 117f, 20f), "Anchor Raft")) 
            {
                if (Hacks.localRaft != null)
                {
                    if (Hacks.raft_driftSpeed == 0f)
                    {
                        Hacks.raft_driftSpeed = Hacks.localRaft.waterDriftSpeed;
                    }
                    if (Hacks.localRaft.waterDriftSpeed == 0f)
                    {
                        Hacks.localRaft.waterDriftSpeed = Hacks.raft_driftSpeed;
                    }
                    else
                    {
                        Hacks.localRaft.waterDriftSpeed = 0f;
                    }
                }
            }
            if (GUI.Button(new Rect(139f, 45f, 117f, 20f), "Teleport To Raft")) 
            {
                Hacks.TeleportToRaft();
            }
            modules.UI.toggleGod = GUI.Toggle(new Rect(139f, 73f, 117f, 20f), modules.UI.t_GOD, "GOD Mode"); 
            if (modules.UI.toggleGod != modules.UI.t_GOD)
            {
                modules.UI.t_GOD = !modules.UI.t_GOD;
            }
            modules.UI.toggleFlyingRaft = GUI.Toggle(new Rect(139f, 98f, 117f, 20f), modules.UI.t_FLYRAFT, "Flying Raft"); 
            if (modules.UI.toggleFlyingRaft != modules.UI.t_FLYRAFT)
            {
                modules.UI.t_FLYRAFT = !modules.UI.t_FLYRAFT;
            }
            
            modules.UI.toggleFlyingSelf = GUI.Toggle(new Rect(139f, 123f, 117f, 20f), modules.UI.t_FLYSELF, "Localplayer Fly"); 
            if (modules.UI.toggleFlyingSelf != modules.UI.t_FLYSELF)
            {
                modules.UI.t_FLYSELF = !modules.UI.t_FLYSELF;
            }

            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

        public static void ItemSpawnWindow(int windowID)
        {
            if (GUI.Button(new Rect(10f, 20f, 120f, 25f), "Give Axe")) 
            {
                Hacks.localPlayer.Inventory.AddItem("Axe", 1);
            }
            if (GUI.Button(new Rect(135f, 20f, 120f, 25f), "Give Battery"))
            {
                Hacks.localPlayer.Inventory.AddItem("Battery", 1);
            }
            if (GUI.Button(new Rect(260f, 20f, 120f, 25f), "Give Ex Powder")) 
            {
                Hacks.localPlayer.Inventory.AddItem("ExplosivePowder", 1);
            }

            if (GUI.Button(new Rect(10f, 50f, 120f, 25f), "Give Bow"))
            {
                Hacks.localPlayer.Inventory.AddItem("Bow", 1);
                Hacks.localPlayer.Inventory.AddItem("Arrow_Stone", 50);
            }
            if (GUI.Button(new Rect(135f, 50f, 120f, 25f), "Give Dry Brick"))
            {
                Hacks.localPlayer.Inventory.AddItem("Brick_Dry", 1);
            }
            if (GUI.Button(new Rect(260f, 50f, 120f, 25f), "Give CircuitBoard"))
            {
                Hacks.localPlayer.Inventory.AddItem("CircuitBoard", 1);
            }

            if (GUI.Button(new Rect(10f, 80f, 120f, 25f), "Give CopperIngot"))
            {
                Hacks.localPlayer.Inventory.AddItem("CopperIngot", 1);
            }
            if (GUI.Button(new Rect(135f, 80f, 120f, 25f), "Give Feather"))
            {
                Hacks.localPlayer.Inventory.AddItem("Feather", 1);
            }
            if (GUI.Button(new Rect(260f, 80f, 120f, 25f), "Give Hammer"))
            {
                Hacks.localPlayer.Inventory.AddItem("Hammer", 1);
            }

            if (GUI.Button(new Rect(10f, 110f, 120f, 25f), "Give Hook"))
            {
                Hacks.localPlayer.Inventory.AddItem("Hook_Scrap", 1);
            }
            if (GUI.Button(new Rect(135f, 110f, 120f, 25f), "Give MetalIngot"))
            {
                Hacks.localPlayer.Inventory.AddItem("MetalIngot", 1);
            }
            if (GUI.Button(new Rect(260f, 110f, 120f, 25f), "Give Nail"))
            {
                Hacks.localPlayer.Inventory.AddItem("Nail", 1);
            }

            if (GUI.Button(new Rect(10f, 140f, 120f, 25f), "Give Plank"))
            {
                Hacks.localPlayer.Inventory.AddItem("Plank", 1);
            }
            if (GUI.Button(new Rect(135f, 140f, 120f, 25f), "Give Plastic"))
            {
                Hacks.localPlayer.Inventory.AddItem("Plastic", 1);
            }
            if (GUI.Button(new Rect(260f, 140f, 120f, 25f), "Give Rope"))
            {
                Hacks.localPlayer.Inventory.AddItem("Rope", 1);
            }

            if (GUI.Button(new Rect(10f, 170f, 120f, 25f), "Give Scrap"))
            {
                Hacks.localPlayer.Inventory.AddItem("Scrap", 1);
            }
            if (GUI.Button(new Rect(135f, 170f, 120f, 25f), "Give Spear"))
            {
                Hacks.localPlayer.Inventory.AddItem("Spear_Scrap", 1);
            }
            if (GUI.Button(new Rect(260f, 170f, 120f, 25f), "Give Stone"))
            {
                Hacks.localPlayer.Inventory.AddItem("Stone", 1);
            }

            if (GUI.Button(new Rect(10f, 200f, 120f, 25f), "Give Palm Leaf"))
            {
                Hacks.localPlayer.Inventory.AddItem("Thatch", 1);
            }
            if (GUI.Button(new Rect(135f, 200f, 120f, 25f), "Give VineGoo"))
            {
                Hacks.localPlayer.Inventory.AddItem("VineGoo", 1);
            }
            if (GUI.Button(new Rect(260f, 200f, 120f, 25f), "Give Radio")) 
            {
                Hacks.localPlayer.Inventory.AddItem("Placeable_Radio", 1);
            }

            if (GUI.Button(new Rect(10f, 230f, 120f, 25f), "Give Blueprints"))
            {
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Antenna", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_BatteryCharger", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_BiofuelExtractor", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_ElectricPurifier", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Firework", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Fueltank", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_HeadLight", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Machete", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_MetalDetector", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_MotorWheel", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Pipe_Fuel", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Pipe_Water", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Reciever", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_SteeringWheel", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_Storage_Large", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_WaterTank", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_ZiplineBase", 1);
                Hacks.localPlayer.Inventory.AddItem("Blueprint_ZiplineTool", 1);
            }
            if (GUI.Button(new Rect(135f, 230f, 120f, 25f), "Give BioFuel"))
            {
                Hacks.localPlayer.Inventory.AddItem("BioFuel", 1);
            }
            if (GUI.Button(new Rect(260f, 230f, 120f, 25f), "Give Cassettes"))
            {
                Hacks.localPlayer.Inventory.AddItem("Cassette_Classical", 1);
                Hacks.localPlayer.Inventory.AddItem("Cassette_EDM", 1);
                Hacks.localPlayer.Inventory.AddItem("Cassette_Elevator", 1);
                Hacks.localPlayer.Inventory.AddItem("Cassette_Pop", 1);
                Hacks.localPlayer.Inventory.AddItem("Cassette_Rock", 1);
            }

            if (GUI.Button(new Rect(10f, 260f, 120f, 25f), "Give TitaniumIngot"))
            {
                Hacks.localPlayer.Inventory.AddItem("TitaniumIngot", 1);
            }
            if (GUI.Button(new Rect(135f, 260f, 120f, 25f), "Give Bee Jar"))
            {
                Hacks.localPlayer.Inventory.AddItem("Jar_Bee", 1);
            }
            if (GUI.Button(new Rect(260f, 260f, 120f, 25f), "Give HoneyComb"))
            {
                Hacks.localPlayer.Inventory.AddItem("HoneyComb", 1);
            }

            GUI.Label(new Rect(10f, 296f, 370f, 25f), "Spawn by name");
            GUI.Label(new Rect(10f, 327f, 50f, 25f), "Name:");
            GUI.Label(new Rect(217f, 327f, 65f, 25f), "Amount:");

            unique_name = GUI.TextField(new Rect(60f, 329f, 151f, 23f), unique_name);
            item_amount = GUI.TextField(new Rect(281f, 329f, 151f, 23f), item_amount);

            if (GUI.Button(new Rect(60f, 359f, 297f, 20f), "Give self custom item"))
            {
                Hacks.localPlayer.Inventory.AddItem(unique_name, Convert.ToInt32(item_amount));
            }

            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

        public static void PlayersWindow(int windowID)
        {
            if (Hacks.NetworkPlayers[currentPlayer] != null)
            {
                GUI.Label(new Rect(15f, 20f, 241f, 25f), $"Name: {Hacks.NetworkPlayers[currentPlayer].characterSettings.Name} [{Hacks.NetworkPlayers.Count}][{currentPlayer}]");//personaname returns localplayer name only
                GUI.Label(new Rect(100f, 50f, 156f, 25f), $"Health: {Hacks.NetworkPlayers[currentPlayer].PersonController.playerStats.stat_health.Value}");
                GUI.Label(new Rect(100f, 80f, 156f, 25f), $"Thirst: {Hacks.NetworkPlayers[currentPlayer].PersonController.playerStats.stat_thirst.Normal.Value}");
                GUI.Label(new Rect(100f, 110f, 156f, 25f), $"Oxygen: {Hacks.NetworkPlayers[currentPlayer].PersonController.playerStats.stat_oxygen.Value}");
                GUI.Label(new Rect(10f, 140f, 112f, 25f), $"Hunger: {Hacks.NetworkPlayers[currentPlayer].PersonController.playerStats.stat_hunger.Normal.Value}");
                GUI.Label(new Rect(126f, 140f, 129f, 25f), $"Local: {Hacks.NetworkPlayers[currentPlayer].IsLocalPlayer}");
                GUI.Label(new Rect(10f, 170f, 246f, 25f), $"Position: X:{Math.Round(Hacks.NetworkPlayers[currentPlayer].transform.position.x, 0)} Y:{Math.Round(Hacks.NetworkPlayers[currentPlayer].transform.position.y, 0)} Z:{Math.Round(Hacks.NetworkPlayers[currentPlayer].transform.position.z, 0)}");
                
                //GUI.DrawTexture(new Rect(10f, 50f, 85f, 85f), Hacks.NetworkPlayers[currentPlayer].GetSmallSteamProfile().texture);
                //Texture2D myTexture = GetTextureFromCamera(Hacks.NetworkPlayers[currentPlayer].Camera);
                //Texture steamPic = Helper.GetSmallSteamAvatarFromID(Hacks.NetworkPlayers[currentPlayer].steamID).texture;
                //if (steamPic != null && steamPic.isReadable)
                //{
                //GUI.DrawTexture(new Rect(95f, 135f, -85f, -85f), Helper.GetSmallSteamAvatarFromID(Hacks.NetworkPlayers[currentPlayer].steamID).texture);
                //}

                if (GUI.Button(new Rect(10f, 204f, 120f, 25f), "Teleport To Player"))
                {
                    Hacks.localPlayer.transform.position = Hacks.NetworkPlayers[currentPlayer].transform.position;
                }
                if (GUI.Button(new Rect(136f, 204f, 120f, 25f), "Teleport To Me"))
                {
                    Hacks.NetworkPlayers[currentPlayer].transform.position = Hacks.localPlayer.transform.position;
                }

                if (GUI.Button(new Rect(10f, 234f, 120f, 25f), "Test"))
                {
                    Hacks.localPlayer.PersonController.swimSpeed = 20f;
                    Hacks.localPlayer.PersonController.sprintSpeed = 20f;
                    Hacks.localPlayer.PersonController.jumpSpeed = 20f;
                    Hacks.localPlayer.PersonController.normalSpeed = 20f;

                }
                if (GUI.Button(new Rect(136f, 234f, 120f, 25f), "Revive"))
                {
                    Bed closestBed = null;

                    if (Hacks.Beds.Count >= 1)
                    {
                        foreach (Bed b in Hacks.Beds)
                        {
                            if (closestBed == null)
                            {
                                closestBed = b;
                            }
                            else
                            {
                                if (Vector3.Distance(b.transform.position, Hacks.localPlayer.transform.position) < Vector3.Distance(closestBed.transform.position, Hacks.localPlayer.transform.position))
                                {
                                    closestBed = b;
                                }
                            }
                        }
                        Hacks.NetworkPlayers[currentPlayer].RessurectComponent.PlaceInBed(closestBed);
                    }
                }
                if (GUI.Button(new Rect(10f, 264f, 120f, 25f), "Previous"))
                {
                    if (currentPlayer == 0)
                    {
                        if (Hacks.NetworkPlayers[Hacks.NetworkPlayers.Count-1] != null)
                        {
                            currentPlayer = Hacks.NetworkPlayers.Count-1;
                        }
                    }
                    else
                    {
                        if (Hacks.NetworkPlayers[currentPlayer - 1] != null)
                        {
                            currentPlayer--;
                        }
                    }
                }
                if (GUI.Button(new Rect(135f, 264f, 120f, 25f), "Next"))
                {
                    if (Hacks.NetworkPlayers[currentPlayer + 1] != null)
                    {
                        currentPlayer++;
                    }
                }
            }
            else
            {
                currentPlayer = 0;
            }
            
            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

        public static void SpeedHackWindow(int windowID)
        {
            if (currentWalkingSpeed == 0f)
            {
                currentWalkingSpeed = Hacks.localPlayer.PersonController.normalSpeed;
            }
            if (currentSprintingSpeed == 0f)
            {
                currentSprintingSpeed = Hacks.localPlayer.PersonController.sprintSpeed;
            }
            if (currentSwimmingSpeed == 0f)
            {
                currentSwimmingSpeed = Hacks.localPlayer.PersonController.swimSpeed;
            }
            if (currentJumpHeight == 0f)
            {
                currentJumpHeight = Hacks.localPlayer.PersonController.jumpSpeed;
            }

            modules.UI.toggleSpeedWalking = GUI.Toggle(new Rect(10f, 20f, 224f, 20f), modules.UI.t_SpeedWalking, "Speed Walking");
            if (modules.UI.toggleSpeedWalking != modules.UI.t_SpeedWalking)
            {
                modules.UI.t_SpeedWalking = !modules.UI.t_SpeedWalking;
            }
            modules.UI.toggleSpeedSprinting = GUI.Toggle(new Rect(10f, 45f, 224f, 20f), modules.UI.t_SpeedSprinting, "Speed Sprinting");
            if (modules.UI.toggleSpeedSprinting != modules.UI.t_SpeedSprinting)
            {
                modules.UI.t_SpeedSprinting = !modules.UI.t_SpeedSprinting;
            }
            modules.UI.toggleSpeedSwimming = GUI.Toggle(new Rect(10f, 70f, 224f, 20f), modules.UI.t_SpeedSwimming, "Speed Swimming");
            if (modules.UI.toggleSpeedSwimming != modules.UI.t_SpeedSwimming)
            {
                modules.UI.t_SpeedSwimming = !modules.UI.t_SpeedSwimming;
            }
            modules.UI.toggleJumpHigh = GUI.Toggle(new Rect(10f, 95f, 224f, 20f), modules.UI.t_JumpHigh, "Jump High");
            if (modules.UI.toggleJumpHigh != modules.UI.t_JumpHigh)
            {
                modules.UI.t_JumpHigh = !modules.UI.t_JumpHigh;
            }

            GUI.Label(new Rect(81f, 120f, 100f, 25f), "- Multiplier -");

            float xMultiply = GUI.HorizontalSlider(new Rect(10f, 147f, 224f, 20f), speedMultiplier, 1f, 100f);
            if (xMultiply != speedMultiplier)
            {
                speedMultiplier = xMultiply;
            }

            GUI.DragWindow(new Rect(0, 0, (float)Screen.width, (float)Screen.height));
        }

    }
}
