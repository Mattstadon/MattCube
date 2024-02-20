using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BootUp : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] SFXManager sfxManager; // Reference to the SFXManager
    [SerializeField] AudioClip buttonClickSound; // Sound effect to play on click
    [SerializeField] float buttonClickVolume = 1f; // Volume for the button click sound
    [SerializeField] Text bootUpText; // Reference to the Text object for boot-up text
    [SerializeField] string fullText = "Initializing system...\nLoading operating system...\nChecking hardware...\nSystem integrity check...\nPreparing to boot...\nLoading user interface...\nEstablishing network connection...\nChecking for updates...\nSystem ready."; // The text to display during boot-up
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

        // Disable the button to prevent further clicks
        button.interactable = false;

        // Start the boot-up sequence
        StartCoroutine(BootUpSequence());
    }

    private IEnumerator BootUpSequence()
    {
        // Start the typing animation
        yield return StartCoroutine(TypeText(bootUpText, fullText, typingSpeed));

        // Wait for the transition time before loading the new scene
        yield return new WaitForSeconds(transitionTime);

        // Load the new scene
        SceneManager.LoadScene("CubeMVP");
    }

    private IEnumerator TypeText(Text textObject, string fullText, float typingSpeed)
    {
        textObject.text = ""; // Clear the text
        string[] lines = fullText.Split('\n'); // Split the text into lines

        foreach (string line in lines)
        {
            foreach (char letter in line.ToCharArray())
            {
                textObject.text += letter; // Add the next character
                yield return new WaitForSeconds(typingSpeed); // Wait before adding the next character
            }

            // Add a newline character after each line
            textObject.text += "\n";
            yield return new WaitForSeconds(typingSpeed * 2); // Wait before starting the next line
        }
    }
}
