using UnityEngine;
using UnityEngine.UI; // Make sure to include this namespace for UI components

[CreateAssetMenu(fileName = "Solution", menuName = "ScriptableObjects/SpawnPuzzleSolutionObject", order = 1)]
public class CubeSolution : ScriptableObject
{
    public int[] combination = new int[9];
    public GameObject thingToSpawn;
    public AudioClip victorySound;
    public float victorySoundVolume = 1f;
    public Text displayText; // Reference to the existing Text component

    public void SolvePuzzle(SFXManager sfxManager)
    {
        // Instantiate the prefab
        Instantiate(thingToSpawn);

        // Set the text of the referenced Text component
        if (displayText != null)
        {
            displayText.text = ""; // The text to display
        }

        if (sfxManager != null && victorySound != null)
        {
            sfxManager.PlaySFX(victorySound, victorySoundVolume);
        }
    }
}
