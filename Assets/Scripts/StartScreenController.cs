using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class StartScreenController : MonoBehaviour
    {
        public void StartGame()
        {
            // Load the main game scene (replace "MainGameScene" with the actual name of your game scene)
            SceneManager.LoadScene("MainGameScene");
        }

        public void QuitGame()
        {
            // Quit the application
            Application.Quit();
        }
    }
}