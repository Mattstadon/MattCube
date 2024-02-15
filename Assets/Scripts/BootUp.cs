using UnityEngine;
using UnityEngine.SceneManagement;

public class BootUp : MonoBehaviour
{
    public void StartUp()
    {
        // Replace "MainGameScene" with the actual name of your main game scene
        SceneManager.LoadScene("CubeMVP");
    }
}
