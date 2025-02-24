using UnityEngine;
using StringsPattern;

namespace PlayerInputHandler
{
    public class PlayerInputKeyboard : PlayerProcessingDevice
    {
        public override Vector3 GetDirectionMovement()
        {
            _directionMovement.x = Input.GetAxisRaw(KeyboardAxes.Horizontal);
            _directionMovement.z = Input.GetAxisRaw(KeyboardAxes.Vertical);

            return _directionMovement.normalized;
        }

        public override bool IsDash()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift)) 
            {
                return true;
            }

            return false;
        }

        public override bool IsJump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                return true;
            }

            return false;
        }
    }
}