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
    [SerializeField] string fullText = "Initializing system...\n Loading operating system...\n Checking hardware...\n System integrity check...\n Preparing to boot...\n Loading user interface...\n Establishing network connection...\n Checking for updates...\n System ready."; // The text to display during boot-up
    [SerializeField] float typingSpeed = 0.1f; // Speed at which the text types out
    [SerializeField] GameObject[] panelsToDisable; // Array of panels to disable

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

        // Disable all panels
        foreach (GameObject panel in panelsToDisable)
        {
            panel.SetActive(false);
        }

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

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            foreach (char letter in line.ToCharArray())
            {
                textObject.text += letter; // Add the next character
                yield return new WaitForSeconds(typingSpeed); // Wait before adding the next character

                // Check if the last three characters are "..."
                if (textObject.text.Length >= 3 && textObject.text.Substring(textObject.text.Length - 3) == "...")
                {
                    // Add a newline character after the "..."
                    textObject.text += "\n";

                    // Check if the line is "Checking for updates..." or the first line
                    if (textObject.text.Contains("Checking for updates...") || i == 0)
                    {
                        // Wait longer before starting the next line
                        yield return new WaitForSeconds(typingSpeed * 6); // Adjust the multiplier as needed
                    }
                    else
                    {
                        // Wait for a short period before starting the next line
                        yield return new WaitForSeconds(typingSpeed * 2); // Adjust the multiplier as needed
                    }
                }
            }
        }
    }
}
