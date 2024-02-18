using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] PuzzleCube[] puzzleCubes;
    [SerializeField] int[] cubeValues;
    [SerializeField] CubeSolution[] possibleSolutions;
    [SerializeField] CubeSolution currentSolution;
    [SerializeField] GameObject objectToDestroy;
    [SerializeField] SFXManager sfxManager;

    void Start()
    {
        puzzleCubes = GetComponentsInChildren<PuzzleCube>();
        cubeValues = new int[puzzleCubes.Length];
    }


    void Update()
    {
        if (currentSolution == null)
        {
            PopulateCubeValues();
        }
    }

    void PopulateCubeValues()
    {
        for (int i = 0; i < puzzleCubes.Length; i++)
        {
            cubeValues[i] = puzzleCubes[i].currentState;
        }

        foreach (CubeSolution solution in possibleSolutions)
        {
            bool matchFound = true;
            for (int i = 0; i < solution.combination.Length; i++)
            {
                if (solution.combination[i] != cubeValues[i])
                {
                    matchFound = false;
                }
            }

            if (matchFound)
            {
                print("Data Recieved");
                currentSolution = solution;
                SpawnTargetObject();
                PlayVictorySound();
            }
        }
    }

    private GameObject spawnedObject;
    void SpawnTargetObject()
    {
        if (currentSolution != null && currentSolution.thingToSpawn != null)
        {
            spawnedObject = Instantiate(currentSolution.thingToSpawn, transform.position, transform.rotation);
        }
    }

    void PlayVictorySound()
    {
        if (currentSolution != null && sfxManager != null)
        {
            sfxManager.PlaySFX(currentSolution.victorySound, currentSolution.victorySoundVolume);
        }
    }

    public void DestroySpawnedObject()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
            currentSolution = null;
            spawnedObject = null;
        }
    }
}
