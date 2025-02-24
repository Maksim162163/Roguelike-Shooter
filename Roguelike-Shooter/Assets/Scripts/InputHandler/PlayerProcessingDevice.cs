using UnityEngine;

namespace PlayerInputHandler
{
    public abstract class PlayerProcessingDevice : MonoBehaviour
    {
        protected Vector3 _directionMovement;

        public abstract Vector3 GetDirectionMovement();

        public abstract bool IsDash();

        public abstract bool IsJump();
    }
}