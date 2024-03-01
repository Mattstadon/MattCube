using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChangeWithDelayAndText : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    [SerializeField] SFXManager sfxManager; // Reference to the SFXManager
    [SerializeField] AudioClip buttonClickSound; // Sound effect to play on click
    [SerializeField] float buttonClickVolume = 1f; // Volume for the button click sound
    [SerializeField] Text displayText; // Reference to the Text object for displaying text
    [SerializeField] string fullText = "Loading the next scene..."; // The text to display during scene change
    [SerializeField] float typingSpeed = 0.1f; // Speed at which the text types out
    [SerializeField] GameObject[] panelsToDisable; // Array of panels to disable
    [SerializeField] string sceneName = "Pudelka AI"; // The name of the scene to load

    private void Awake()
    {
        Button button = GetComponent<Button>(); // Get the Button component
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

        // Disable all buttons in the scene
        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }

        // Disable all panels
        foreach (GameObject panel in panelsToDisable)
        {
            panel.SetActive(false);
        }

        // Start the scene change sequence
        StartCoroutine(SceneChangeSequence());
    }

    private IEnumerator SceneChangeSequence()
    {
        // Start the typing animation
        yield return StartCoroutine(TypeText(displayText, fullText, typingSpeed));

        // Wait for the transition time before loading the new scene
        yield return new WaitForSeconds(transitionTime);

        // Load the new scene
        SceneManager.LoadScene(sceneName);
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


