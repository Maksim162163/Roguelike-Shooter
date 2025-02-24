using UnityEngine;

namespace Character
{
    public class CharacterJump : CharacterMovement, IJumpable
    {
        [SerializeField] private float _maxJumpTime;
        [SerializeField] private float _maxJumpHeight;

        private IAttractable _characterAttraction;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAttraction = GetComponent<IAttractable>();

            float _maxHeightTime = _maxJumpTime / 2;
            _characterAttraction.GravityForce = (2 * _maxJumpHeight) / Mathf.Pow(_maxHeightTime, 2);
            _moveDirection.y = (2 * _maxJumpHeight) / _maxHeightTime;
        }

        public void JumpCharacter()
        {
            if (_characterController.isGrounded)
            {
                _characterController.Move(_moveDirection);
            }
        }
    }
}