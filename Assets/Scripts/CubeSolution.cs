using UnityEngine;

[CreateAssetMenu(fileName = "Solution", menuName = "ScriptableObjects/SpawnPuzzleSolutionObject", order = 1)]
public class CubeSolution : ScriptableObject
{
    public int[] combination = new int[9];
    public GameObject thingToSpawn;
    [SerializeField] AudioClip victorySound; // Victory sound effect
    [SerializeField] float victorySoundVolume = 1f; // Volume for the victory sound

    // Method to be called when the puzzle is solved
    public void SolvePuzzle(SFXManager sfxManager)
    {
        // Spawn the solution object
        Instantiate(thingToSpawn);

        // Play the victory sound effect with the specified volume
        if (sfxManager != null && victorySound != null)
        {
            sfxManager.PlaySFX(victorySound, victorySoundVolume);
        }
    }
}
