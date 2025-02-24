using UnityEngine;

namespace Character
{
    public class CharacterWalking : CharacterMovement, IMovable
    {
        [SerializeField] private float _moveSpeed;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void WalkCharacter(Vector3 moveDirection)
        {
            _moveDirection = CalculateWalking(moveDirection);
            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        private Vector3 CalculateWalking(Vector3 moveDirection)
        {
            _moveDirection = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            _moveDirection *= _moveSpeed;
            return _moveDirection;
        }
    }
}