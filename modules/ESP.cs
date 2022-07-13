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
        private static Hacks h = new Hacks();
        public void esp(Network_Player sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos1 = sprite.transform.position;
            Vector3 playerFootPos1; playerFootPos1.x = pivotPos1.x; playerFootPos1.z = pivotPos1.z; playerFootPos1.y = pivotPos1.y - 2f;
            Vector3 playerHeadPos1; playerHeadPos1.x = playerFootPos1.x; playerHeadPos1.z = playerFootPos1.z; playerHeadPos1.y = playerFootPos1.y + 4f;

            Vector3 w2s_playerFoot1 = Camera.main.WorldToScreenPoint(playerFootPos1);
            Vector3 w2s_playerHead1 = Camera.main.WorldToScreenPoint(playerHeadPos1);

            if (w2s_playerFoot1.z > 0f)
            {
                DrawESP(w2s_playerFoot1, w2s_playerHead1, Color.green, sprite.Network.PersonaName, sprite.Stats.stat_health.Value.ToString());
            }
        }

        public void raftesp(RaftBounds sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 w2s_bl = Camera.main.WorldToScreenPoint(sprite.BottomLeft);
            Vector3 w2s_br = Camera.main.WorldToScreenPoint(sprite.BottomRight);
            Vector3 w2s_tl = Camera.main.WorldToScreenPoint(sprite.TopLeft);
            Vector3 w2s_tr = Camera.main.WorldToScreenPoint(sprite.TopRight);

            Render.DrawLine(new Vector2(w2s_bl.x, (float)Screen.height - w2s_bl.y), new Vector2(w2s_br.x, (float)Screen.height - w2s_br.y), Color.yellow, 2f);
            Render.DrawLine(new Vector2(w2s_br.x, (float)Screen.height - w2s_br.y), new Vector2(w2s_tr.x, (float)Screen.height - w2s_tr.y), Color.yellow, 2f);
            Render.DrawLine(new Vector2(w2s_tr.x, (float)Screen.height - w2s_tr.y), new Vector2(w2s_tl.x, (float)Screen.height - w2s_tl.y), Color.yellow, 2f);
            Render.DrawLine(new Vector2(w2s_tl.x, (float)Screen.height - w2s_tl.y), new Vector2(w2s_bl.x, (float)Screen.height - w2s_bl.y), Color.yellow, 2f);

        }

        public void esp(PickupItem_Networked sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos1 = sprite.transform.position;
            Vector3 playerFootPos1; playerFootPos1.x = pivotPos1.x; playerFootPos1.z = pivotPos1.z; playerFootPos1.y = pivotPos1.y - 0f;
            Vector3 playerHeadPos1; playerHeadPos1.x = playerFootPos1.x; playerHeadPos1.z = playerFootPos1.z; playerHeadPos1.y = playerFootPos1.y + 2f;

            Vector3 w2s_playerFoot1 = Camera.main.WorldToScreenPoint(playerFootPos1);
            Vector3 w2s_playerHead1 = Camera.main.WorldToScreenPoint(playerHeadPos1);

            float distance = Vector3.Distance(pivotPos1, localPlayer.transform.position);

            if (w2s_playerFoot1.z > 0f && distance <= 70f)
            {
                DrawText(w2s_playerFoot1, w2s_playerHead1, $"{sprite.PickupItem.PickupName}", Color.red);
            }
        }

        public void esp(Raft sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos1 = sprite.transform.position;
            Vector3 playerFootPos1; playerFootPos1.x = pivotPos1.x; playerFootPos1.z = pivotPos1.z; playerFootPos1.y = pivotPos1.y - 2f;
            Vector3 playerHeadPos1; playerHeadPos1.x = playerFootPos1.x; playerHeadPos1.z = playerFootPos1.z; playerHeadPos1.y = playerFootPos1.y + 4f;

            Vector3 w2s_playerFoot1 = Camera.main.WorldToScreenPoint(playerFootPos1);
            Vector3 w2s_playerHead1 = Camera.main.WorldToScreenPoint(playerHeadPos1);

            float distance = Vector3.Distance(pivotPos1, localPlayer.transform.position);

            if (w2s_playerFoot1.z > 0f && distance <= 70f)
            {
                DrawText(w2s_playerFoot1, w2s_playerHead1, $"Name: {sprite.name} | Type: {sprite.GetType()} ", Color.yellow);
            }
        }

        public void esp(Network_Entity sprite, Color color, String text, Network_Player localPlayer)
        {
            Vector3 pivotPos = sprite.transform.position;
            Vector3 playerFootPos; playerFootPos.x = pivotPos.x; playerFootPos.z = pivotPos.z; playerFootPos.y = pivotPos.y - 2f;
            Vector3 playerHeadPos; playerHeadPos.x = playerFootPos.x; playerHeadPos.z = playerFootPos.z; playerHeadPos.y = playerFootPos.y + 2f;

            Vector3 w2s_playerFoot = Camera.main.WorldToScreenPoint(playerFootPos);
            Vector3 w2s_playerHead = Camera.main.WorldToScreenPoint(playerHeadPos);
            
            if (w2s_playerFoot.z > 0f && sprite.entityType != EntityType.Player)
            {
                float distance = Vector3.Distance(pivotPos, localPlayer.transform.position);

                if (sprite.IsDead)
                {
                    DrawESP(w2s_playerFoot, w2s_playerHead, Color.red, sprite.name + $" [{Math.Round(distance, 0)}]", sprite.stat_health.Value.ToString());
                }
                else
                {
                    DrawESP(w2s_playerFoot, w2s_playerHead, Color.yellow, sprite.name + $" [{Math.Round(distance, 0)}]", sprite.stat_health.Value.ToString());
                }
            }
        }

        public void DrawESP(Vector3 objfootPos, Vector3 objheadPos, Color objColor, String name, String health)
        {
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawBox(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height, width, height, objColor, 2f);
            if (health != "")
            {
                Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - height), $"{name} [{health}]", Color.magenta);
            }
        }
        public void DrawText(Vector3 objfootPos, Vector3 objheadPos, String name, Color color)
        {
            float height = objheadPos.y - objfootPos.y;
            float widthOffset = 2f;
            float width = height / widthOffset;

            Render.DrawString(new Vector2(objfootPos.x - (width / 2), (float)Screen.height - objfootPos.y - (height / 2)), $"{name}", color);
        }

    }
}
