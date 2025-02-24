using UnityEngine;
using StringsPattern;
using UnityEngine.SceneManagement;

namespace UIMenu
{
    public class MenuButtonManager : MonoBehaviour
    {
        public void PlayNewGame()
        {
            SceneManager.LoadScene(Scenes.GameRoom);
            Time.timeScale = 1.0f;
        }

        public void ContinueGame()
        {

            Time.timeScale = 1.0f;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}