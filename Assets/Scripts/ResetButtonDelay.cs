using UnityEngine;
using UnityEngine.UI;

public class ResetButtonDelay : MonoBehaviour
{
    [SerializeField] SFXManager sfxManager; // Reference to the SFXManager
    [SerializeField] AudioClip buttonClickSound; // Sound effect to play on click
    [SerializeField] float buttonClickVolume = 1f; // Volume for the button click sound
    [SerializeField] float soundDelay = 5f; // Delay in seconds before playing the sound

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
            // Use Invoke to delay the sound effect
            Invoke("PlaySoundEffect", soundDelay);
        }
    }

    private void PlaySoundEffect()
    {
        sfxManager.PlaySFX(buttonClickSound, buttonClickVolume); // Play the sound effect
    }
}
