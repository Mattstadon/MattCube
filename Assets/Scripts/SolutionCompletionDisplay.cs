using UnityEngine;
using UnityEngine.UI;

public class SolutionCompletionDisplay : MonoBehaviour
{
    [SerializeField] private Text solutionCompletionText; // Reference to the Text component
    [SerializeField] private PuzzleCube[] puzzleCubes; // Array of PuzzleCube scripts
    [SerializeField] private int[] solutionStates; // Array of correct rotation states for the solution

    private void Update()
    {
        // Check if the solution is completed
        if (IsSolutionCompleted())
        {
            // Update the text to indicate the solution is completed
            solutionCompletionText.text = "Solution Completed!";
        }
        else
        {
            // Clear the text if the solution is not completed
            solutionCompletionText.text = "";
        }
    }

    private bool IsSolutionCompleted()
    {
        // Check if all cubes are in the correct rotation state
        for (int i = 0; i < puzzleCubes.Length; i++)
        {
            if (puzzleCubes[i].currentState != solutionStates[i])
            {
                return false;
            }
        }
        return true;
    }
}

