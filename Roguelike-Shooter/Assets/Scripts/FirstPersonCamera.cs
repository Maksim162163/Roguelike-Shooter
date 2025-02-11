using UnityEngine;
using Axes;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _maxYAngle = 80f;
    [SerializeField] private float _mouseSensitivity = 200f;

    private float _inversionMouseY;
    private float _mouseX;
    private float _mouseY;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        _mouseX = Input.GetAxis(MouseAxes.MouseX) * _mouseSensitivity;
        _mouseY = Input.GetAxis(MouseAxes.MouseY) * _mouseSensitivity;

        _inversionMouseY -= _mouseY;
        _inversionMouseY = Mathf.Clamp(_inversionMouseY, -_maxYAngle, _maxYAngle);
    }

    private void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(_inversionMouseY, 0f, 0f);
        _playerBody.Rotate(_mouseX * Vector3.up);
    }
}
