using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RaftHax.modules
{
    class ESP : MonoBehaviour
    {
        private static Vector3 pHead, pNeck, pChest, pSpine, pHips;
        private static Vector3 pThighL, pThighR, pShinL, pShinR, pFootL, pFootR;
        private static Vector3 pShoulderR, pShoulderL, pUpperArmR, pUpperArmL, pForearm_L, pForearm_R, pHandL, pHandR;
        
        public static void esp(Network_Player sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos1 = sprite.transform.position;
            Vector3 playerFootPos1; playerFootPos1.x = pivotPos1.x; playerFootPos1.z = pivotPos1.z; playerFootPos1.y = pivotPos1.y - 2f;
            Vector3 playerHeadPos1; playerHeadPos1.x = playerFootPos1.x; playerHeadPos1.z = playerFootPos1.z; playerHeadPos1.y = playerFootPos1.y + 4f;

            Vector3 w2s_playerFoot1 = Camera.main.WorldToScreenPoint(playerFootPos1);
            Vector3 w2s_playerHead1 = Camera.main.WorldToScreenPoint(playerHeadPos1);

            if (Vector3.Distance(sprite.transform.position, localPlayer.transform.position) >= 3f && w2s_playerFoot1.z > 0f && (IsOnScreen(w2s_playerFoot1) || IsOnScreen(playerHeadPos1)))
            {
                if (UI.t_DrawBox)
                {
                    DrawESP(w2s_playerFoot1, w2s_playerHead1, Color.green, sprite.characterSettings.Name + " [" + sprite.Stats.stat_health.Value.ToString() + "]");
                }
                if (UI.t_DrawSkeleton)
                {
                    Transform[] entityBones = sprite.GetComponentInChildren<SkinnedMeshRenderer>().bones;

                    int canDraw = 0;

                    for (int j = 0; j < entityBones.Length; j++)
                    {
                        //Torso & Head
                        if (entityBones[j].name == "DEF-head") { pHead = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-neck") { pNeck = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-chest") { pChest = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-spine") { pSpine = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-hips") { pHips = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //

                        //Legs
                        if (entityBones[j].name == "DEF-thigh_01_R") { pThighR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-thigh_01_L") { pThighL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-shin_02_L") { pShinL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-shin_02_R") { pShinR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-foot_L") { pFootL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-foot_R") { pFootR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //

                        //Arms
                        if (entityBones[j].name == "DEF-shoulder_L") { pShoulderL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-shoulder_R") { pShoulderR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-upper_arm_01_L") { pUpperArmL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-upper_arm_01_R") { pUpperArmR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-forearm_01_L") { pForearm_L = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-forearm_01_R") { pForearm_R = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-hand_L") { pHandL = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //
                        if (entityBones[j].name == "DEF-hand_R") { pHandR = Camera.current.WorldToScreenPoint(entityBones[j].transform.position); canDraw++; } //

                    }

                    if (canDraw == 19)
                    {
                        DrawBoneLine(pHead, pNeck, Color.magenta);
                        DrawBoneLine(pNeck, pChest, Color.magenta);
                        DrawBoneLine(pChest, pSpine, Color.magenta);
                        DrawBoneLine(pSpine, pHips, Color.magenta);

                        DrawBoneLine(pHips, pThighR, Color.magenta);
                        DrawBoneLine(pHips, pThighL, Color.magenta);
                        DrawBoneLine(pThighR, pShinR, Color.magenta);
                        DrawBoneLine(pThighL, pShinL, Color.magenta);
                        DrawBoneLine(pShinR, pFootR, Color.magenta);
                        DrawBoneLine(pShinL, pFootL, Color.magenta);

                        DrawBoneLine(pNeck, pShoulderL, Color.magenta);
                        DrawBoneLine(pNeck, pShoulderR, Color.magenta);
                        DrawBoneLine(pShoulderL, pUpperArmL, Color.magenta);
                        DrawBoneLine(pShoulderR, pUpperArmR, Color.magenta);
                        DrawBoneLine(pUpperArmL, pForearm_L, Color.magenta);
                        DrawBoneLine(pUpperArmR, pForearm_R, Color.magenta);
                        DrawBoneLine(pForearm_L, pHandL, Color.magenta);
                        DrawBoneLine(pForearm_R, pHandR, Color.magenta);
                    }
                }
                if (UI.t_DrawLines)
                {
                    Render.DrawLine(new Vector2((float)Screen.width / 2, (float)Screen.height), new Vector2(w2s_playerFoot1.x, (float)Screen.height - w2s_playerFoot1.y), Color.magenta, 2f);
                }

            }
        }

        public static void raftesp(RaftBounds sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 w2s_raftC = Camera.main.WorldToScreenPoint(sprite.Center);
            
            float distance = Vector3.Distance(sprite.Center, localPlayer.transform.position);
            
            if (distance >= 1f && distance <= UI.esp_slider_distance && w2s_raftC.z >= 0)
            {
                if (UI.t_DrawLines)
                {
                    Render.DrawLine(new Vector2((float)Screen.width / 2, (float)Screen.height), new Vector2(w2s_raftC.x, (float)Screen.height - w2s_raftC.y), Color.cyan, 2f);
                }
                if (UI.t_DrawBox)
                {

                }
                if (UI.t_DrawLabels)
                {
                    DrawText(w2s_raftC, $"Raft", Color.cyan);
                }
            }
        }

        public static void itemesp(PickupItem_Networked sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos1 = sprite.transform.position;

            Vector3 w2s_objpos = Camera.main.WorldToScreenPoint(pivotPos1);

            float distance = Vector3.Distance(pivotPos1, localPlayer.transform.position);

            if (IsOnScreen(w2s_objpos) && distance <= UI.esp_slider_distance)
            {
                if (UI.t_DistanceFade)
                {
                    DrawText(w2s_objpos, $"{sprite.PickupItem.PickupName}", lib.NuColor.RGBAtoColor(255, 0, 0, 255 - (distance * 1.5f)));
                }
                else
                {
                    DrawText(w2s_objpos, $"{sprite.PickupItem.PickupName}", lib.NuColor.RGBtoColor(255, 0, 0));
                }
            }
        }

        public static void netesp(Network_Entity sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos = sprite.transform.position;
            Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f;
            Vector3 playerHeadPos; playerHeadPos.x = playerFootPos.x; playerHeadPos.z = playerFootPos.z; playerHeadPos.y = playerFootPos.y + 2f;

            Vector3 w2s_playerFoot = Camera.current.WorldToScreenPoint(playerFootPos);
            Vector3 w2s_playerHead = Camera.current.WorldToScreenPoint(playerHeadPos);

            float distance = Vector3.Distance(pivotPos, localPlayer.transform.position);

            if ((IsOnScreen(w2s_playerFoot) || IsOnScreen(w2s_playerHead)) && sprite.entityType == EntityType.Enemy || sprite.entityType == EntityType.Environment)
            {
                
                if (UI.t_DrawBox)
                {
                    if (sprite.IsDead)
                    {
                        DrawESP(w2s_playerFoot, w2s_playerHead, Color.red, sprite.name + $" [{Math.Round(distance, 0)}] Health: {sprite.stat_health.Value.ToString()}");
                    }
                    else
                    {
                        DrawESP(w2s_playerFoot, w2s_playerHead, Color.yellow, sprite.name + $" [{Math.Round(distance, 0)}] Health: {sprite.stat_health.Value.ToString()}");
                    }
                }
                if (UI.t_DrawLabels && !UI.t_DrawBox)
                {
                    DrawText(Camera.main.WorldToScreenPoint(pivotPos), sprite.name, Color.yellow);
                }
                if (UI.t_DrawLines)
                {
                    DrawLine(Camera.main.WorldToScreenPoint(pivotPos), Color.yellow);
                }
                
            }
        }

        public static void DrawESP(Vector3 objfootPos, Vector3 objheadPos, Color objColor, String name)
        {
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawBox(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height, objColor, 2f);
            Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height), $"{name}", Color.magenta);
        }
        public static void DrawText(Vector3 w2s_object, String name, Color color)
        {
           Render.DrawString(new Vector2(w2s_object.x, (float)Screen.height - w2s_object.y), $"{name}", color);
        }
        public static void DrawLine(Vector3 w2s_object, Color color)
        {
            Render.DrawLine(new Vector2((float)Screen.width / 2, (float)Screen.height), new Vector2(w2s_object.x, (float)Screen.height - w2s_object.y), Color.magenta, 2f);
        }
        public static void DrawBoneLine(Vector3 w2s_objectStart, Vector3 w2s_objectFinish, Color color)
        {
            Render.DrawLine(new Vector2(w2s_objectStart.x, (float)Screen.height - w2s_objectStart.y), new Vector2(w2s_objectFinish.x, (float)Screen.height - w2s_objectFinish.y), color, 1f);
        }
        public static bool IsOnScreen(Vector3 position)
        {
            return position.y > 0.01f && position.y < Screen.height && position.z > 0f && position.x > 0f && position.x < Screen.width;
        }
    }
}
