using UnityEngine;

[CreateAssetMenu(fileName = "Solution", menuName = "ScriptableObjects/SpawnPuzzleSolutionObject", order = 1)]
public class CubeSolution : ScriptableObject
{
    public int[] combination = new int[9];
    public GameObject thingToSpawn;
}