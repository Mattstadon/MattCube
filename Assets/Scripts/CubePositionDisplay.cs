using UnityEngine;
using UnityEngine.UI;

public class CubePositionDisplay : MonoBehaviour
{
    [SerializeField] private Text cubeStateText; // Reference to the Text component
    [SerializeField] private PuzzleCube[] puzzleCubes; // Array of PuzzleCube scripts

    private void Update()
    {
        // Update the text with the cube rotation states
        string states = "";
        foreach (PuzzleCube puzzleCube in puzzleCubes)
        {
            if (puzzleCube != null)
            {
                states += "Cube State: " + puzzleCube.currentState + "\n";
            }
        }
        cubeStateText.text = states;
    }
}
