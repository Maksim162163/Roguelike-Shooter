using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterAttraction : CharacterMovement, IAttractable
    {
        private float _gravityForce;
        public float GravityForce
        {
            set
            {
                if (value >= 0.0f)
                    _gravityForce = value;
                else
                    _gravityForce = 0.0f;
            }
        }

        private float _currentAttractionCharacter = 0f;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private float CalculateGravity()
        {
            if (!_characterController.isGrounded)
            {
                _currentAttractionCharacter -= _gravityForce * Time.deltaTime;
                return _currentAttractionCharacter;
            }
            else
            {
                _currentAttractionCharacter = 0.0f;
                return _currentAttractionCharacter;
            }
        }

        public void AttractCharacter()
        {
            _moveDirection.y += CalculateGravity();
            _characterController.Move(_moveDirection);
        }
    }
}