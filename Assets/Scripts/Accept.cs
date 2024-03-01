using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Accept : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] SFXManager sfxManager; // Reference to the SFXManager
    [SerializeField] AudioClip buttonClickSound; // Sound effect to play on click
    [SerializeField] float buttonClickVolume = 1f; // Volume for the button click sound
    [SerializeField] Text displayText; // UI Text component for displaying messages
    [SerializeField] string sceneName = "Boot Up"; // Scene to switch to
    [SerializeField] float delay = 2f; // Delay in seconds before switching scenes
    [SerializeField] string fullText = "Exiting program..."; // The text to display during boot-up
    [SerializeField] float typingSpeed = 0.1f; // Speed at which the text types out

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
        StartCoroutine(BootUpSequence());
    }

    private IEnumerator BootUpSequence()
    {
        // Disable the button to prevent further clicks
        button.interactable = false;

        // Start the typing animation
        yield return StartCoroutine(TypeText(displayText, fullText, typingSpeed));

        // Wait for the specified delay before switching scenes
        yield return new WaitForSeconds(delay);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator TypeText(Text textObject, string fullText, float typingSpeed)
    {
        textObject.text = ""; // Clear the text
        foreach (char letter in fullText.ToCharArray())
        {
            textObject.text += letter; // Add the next character
            yield return new WaitForSeconds(typingSpeed); // Wait before adding the next character
        }
    }
}
