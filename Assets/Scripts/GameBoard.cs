using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class GameBoard : MonoBehaviour
{
    [SerializeField] PuzzleCube[] puzzleCubes;
    [SerializeField] int[] cubeValues;
    [SerializeField] CubeSolution[] possibleSolutions;
    [SerializeField] CubeSolution currentSolution;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCubes = GetComponentsInChildren<PuzzleCube>();
        cubeValues = new int[puzzleCubes.Length];
    }

    // Update is called once per frame
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
            }
        }
    }

    void SpawnTargetObject()
    {
        if (currentSolution != null)
        {
            GameObject objectToSpawn = currentSolution.thingToSpawn;
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, transform.position, Quaternion.identity);
                //currentSolution = null;
            }
        }
    }
}
