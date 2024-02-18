using UnityEngine;

[CreateAssetMenu(fileName = "Solution", menuName = "ScriptableObjects/SpawnPuzzleSolutionObject", order = 1)]
public class CubeSolution : ScriptableObject
{
    public int[] combination = new int[9];
    public GameObject thingToSpawn;
    public AudioClip victorySound;
    public float victorySoundVolume = 1f;


    public void SolvePuzzle(SFXManager sfxManager)
    {

        Instantiate(thingToSpawn);


        if (sfxManager != null && victorySound != null)
        {
            sfxManager.PlaySFX(victorySound, victorySoundVolume);
        }
    }
}