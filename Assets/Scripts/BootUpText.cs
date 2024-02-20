using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BootUpText : MonoBehaviour
{
    public Text textObject;
    public string fullText = "Initializing system...\n Loading operating system...\n Checking hardware...\n System integrity check...\n Preparing to boot...\n Loading user interface...\n Establishing network connection...\n Checking for updates...\n System ready.";
    public float typingSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textObject.text = "\n"; // Clear the text
        foreach (char letter in fullText.ToCharArray())
        {
            textObject.text += letter; // Add the next character
            yield return new WaitForSeconds(typingSpeed); // Wait before adding the next character
        }
    }
}
