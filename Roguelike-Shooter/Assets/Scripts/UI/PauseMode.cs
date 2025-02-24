using UnityEngine;
using StringsPattern;
using UnityEngine.SceneManagement;
using InputDevices;
using UIInputHandler;

namespace UIPause
{
    public class PauseMode : MonoBehaviour
    {
        public static bool IsPause;
        [SerializeField] private GameObject _pausePanel;

        private UIProcessingDevice _deviceHandler;
        private Devices _deviceName;

        private void Awake()
        {
            IsPause = false;
            _deviceName = (Devices)PlayerPrefs.GetInt(Settings.SelectedInputDevice);

            if (_deviceName == Devices.Keyboard)
            {
                _deviceHandler = GetComponent<UIInputKeyboard>();
            }
        }

        private void Update()
        {
            CheckPause();
        }

        private void CheckPause()
        {
            if (_deviceHandler.IsPause())
            {
                Time.timeScale = 0.0f;
                _pausePanel.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                IsPause = true;
            }
        }

        public void ResumeGame()
        {
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
            _pausePanel.SetActive(false);
            IsPause = false;
        }

        public void GoMenu()
        {
            SceneManager.LoadScene(Scenes.Menu);
        }
    }
}
