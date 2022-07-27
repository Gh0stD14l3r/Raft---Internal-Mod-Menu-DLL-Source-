using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaftHax.modules
{
    class SpeedHack
    {
        public static void speedHack()
        {
            if (modules.UI.t_SpeedWalking && modules.UI.currentWalkingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.normalSpeed = modules.UI.currentWalkingSpeed * modules.UI.speedMultiplier;
            }
            else if (modules.UI.currentWalkingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.normalSpeed = modules.UI.currentWalkingSpeed;
            }
            if (modules.UI.t_SpeedSprinting && modules.UI.currentSprintingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.sprintSpeed = modules.UI.currentSprintingSpeed * modules.UI.speedMultiplier;
            }
            else if (modules.UI.currentSprintingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.sprintSpeed = modules.UI.currentSprintingSpeed;
            }
            if (modules.UI.t_SpeedSwimming && modules.UI.currentSwimmingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.swimSpeed = modules.UI.currentSwimmingSpeed * modules.UI.speedMultiplier;
            }
            else if (modules.UI.currentSwimmingSpeed > 0)
            {
                Hacks.localPlayer.PersonController.swimSpeed = modules.UI.currentSwimmingSpeed;
            }
            if (modules.UI.t_JumpHigh && modules.UI.currentJumpHeight > 0)
            {
                Hacks.localPlayer.PersonController.jumpSpeed = modules.UI.currentJumpHeight * modules.UI.speedMultiplier;
            }
            else if (modules.UI.currentJumpHeight > 0)
            {
                Hacks.localPlayer.PersonController.jumpSpeed = modules.UI.currentJumpHeight;
            }
        }
    }
}
