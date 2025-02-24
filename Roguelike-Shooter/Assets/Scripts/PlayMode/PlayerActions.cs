using StringsPattern;
using InputDevices;
using PlayerInputHandler;
using UnityEngine;

namespace Player
{
    public class PlayerActions : MonoBehaviour
    {
        private PlayerProcessingDevice _deviceHandler;
        private Devices _deviceName;
        private IMovable _playerMovement;
        private IJumpable _playerJump;
        private IAttractable _playerAttract;

        private void Awake()
        {
            _deviceName = (Devices)PlayerPrefs.GetInt(Settings.SelectedInputDevice);

            if (_deviceName == Devices.Keyboard)
            {
                _deviceHandler = GetComponent<PlayerInputKeyboard>();
            }

            _playerMovement = GetComponent<IMovable>();
            _playerAttract = GetComponent<IAttractable>();
            _playerJump = GetComponent<IJumpable>();
        }

        private void Update()
        {
            if (_deviceName == Devices.Keyboard)
            {
                Vector3 directionMovement = _deviceHandler.GetDirectionMovement();
                _playerMovement.WalkCharacter(directionMovement);

                if (_deviceHandler.IsJump())
                {
                    _playerJump.JumpCharacter();
                }

                _playerAttract.AttractCharacter();
            }
        }
    }
}
