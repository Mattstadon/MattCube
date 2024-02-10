using UnityEngine;
using UnityEngine.UI;

public class ButtonSFXHandler : MonoBehaviour
{
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
}
