using UnityEngine;
using StringsPattern;
using UIPause;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _maxYAngle = 80f;
    [SerializeField] private float _mouseSensitivity = 3f;

    private float _inversionMouseY;
    private float _mouseX;
    private float _mouseY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!PauseMode.IsPause)
        {
            _mouseX = Input.GetAxis(MouseAxes.MouseX) * _mouseSensitivity;
            _mouseY = Input.GetAxis(MouseAxes.MouseY) * _mouseSensitivity;

            _inversionMouseY -= _mouseY;
            _inversionMouseY = Mathf.Clamp(_inversionMouseY, -_maxYAngle, _maxYAngle);
        }
    }

    private void LateUpdate()
    {
        if (!PauseMode.IsPause)
        {
            transform.localRotation = Quaternion.Euler(_inversionMouseY, 0f, 0f);
            _playerBody.Rotate(_mouseX * Vector3.up);
        }
    }
}
