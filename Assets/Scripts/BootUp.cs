using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.TimeZoneInfo;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class BootUp : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    [SerializeField] SFXManager sfxManager; // Reference to the SFXManager
    [SerializeField] AudioClip buttonClickSound; // Sound effect to play on click
    [SerializeField] float buttonClickVolume = 1f; // Volume for the button click sound

    private Button button; // Reference to the UI Button component

    private void Awake()
    {
        button = GetComponent<Button>(); // Get the Button component
        if (button != null)
        {
            button.onClick.AddListener(HandleButtonClick); // Subscribe to the onClick event
        }
    }

    private void HandleButtonClick()
    {
        if (sfxManager != null && buttonClickSound != null)
        {
            sfxManager.PlaySFX(buttonClickSound, buttonClickVolume); // Play the sound effect
        }
    }
    public void StartUp()
    {
        // Replace "MainGameScene" with the actual name of your main game scene
        SceneManager.LoadScene("CubeMVP");
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
