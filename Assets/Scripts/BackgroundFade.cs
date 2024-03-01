using UnityEngine;
using UnityEngine.UI;

public class BackgroundFade : MonoBehaviour
{
    public Image backgroundImage; // Assign your UI Image component in the Inspector
    public float fadeSpeed = 1f; // Speed of the fade effect
    public Button triggerButton; // The button that triggers the fade

    private bool isFadingIn = true; // Flag to track the current fade state
    private bool isFading = false; // Flag to track if the fade effect is currently active

    void Start()
    {
        // Subscribe to the button's click event
        triggerButton.onClick.AddListener(ToggleFade);
    }

    void Update()
    {
        if (!isFading) return; // If not fading, do nothing

        // Adjust the alpha value based on the current fade state
        float alphaChange = isFadingIn ? Time.deltaTime * fadeSpeed : -Time.deltaTime * fadeSpeed;
        backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, backgroundImage.color.a + alphaChange);

        // Check if the fade has completed
        if (isFadingIn && backgroundImage.color.a >= 1f)
        {
            isFadingIn = false; // Switch to fading out
        }
        else if (!isFadingIn && backgroundImage.color.a <= 0f)
        {
            isFading = false; // Fade completed, stop fading
        }
    }

    public void ToggleFade()
    {
        if (!isFading)
        {
            isFading = true; // Start fading
            isFadingIn = true; // Ensure we start fading in
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0f);
        }
    }
}
