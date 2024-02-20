using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BootUpText : MonoBehaviour
{
    public Text textObject;
    public string fullText = "Booting up...";
    public float typingSpeed = 0.1f;

    private void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        textObject.text = ""; // Clear the text
        foreach (char letter in fullText.ToCharArray())
        {
            textObject.text += letter; // Add the next character
            yield return new WaitForSeconds(typingSpeed); // Wait before adding the next character
        }
    }
}
