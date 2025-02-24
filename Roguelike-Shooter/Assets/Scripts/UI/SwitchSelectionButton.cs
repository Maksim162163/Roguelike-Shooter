using TMPro;
using UnityEngine;
using UnityEngine.UI;
using InputDevices;
using StringsPattern;
using System;

public class SwitchSelectionButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textDevice;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _rightButton;

    private Devices _selectedDevice;

    private void Awake()
    {
        _selectedDevice = (Devices)PlayerPrefs.GetInt(Settings.SelectedInputDevice, (int)Devices.Keyboard);
        UpdateDisplay();

        _leftButton.onClick.AddListener(PreviousOption);
        _rightButton.onClick.AddListener(NextOption);
    }

    private void NextOption()
    {
        _selectedDevice = (Devices)(((int)_selectedDevice + 1) % Enum.GetNames(typeof(Devices)).Length);
        UpdateDisplay();
        SaveSelection();
    }

    private void PreviousOption()
    {
        _selectedDevice = (Devices)(Mathf.Abs(((int)_selectedDevice - 1) % Enum.GetNames(typeof(Devices)).Length));
        UpdateDisplay();
        SaveSelection();
    }

    private void UpdateDisplay()
    {
        if (_selectedDevice == Devices.Keyboard)
        {
            _textDevice.text = "Keyboard";
        }
    }

    private void SaveSelection()
    {
        PlayerPrefs.SetInt(Settings.SelectedInputDevice, (int)_selectedDevice);
        PlayerPrefs.Save();
    }
}
