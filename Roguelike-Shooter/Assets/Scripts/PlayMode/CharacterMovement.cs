using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        protected CharacterController _characterController;
        protected Vector3 _moveDirection;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }
    }
}
