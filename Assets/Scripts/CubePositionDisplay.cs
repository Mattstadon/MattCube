using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class CubePositionDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cubeStateText; // Reference to the TextMeshProUGUI component
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
        cubeStateText.text = states; // Use TextMeshPro's text property
    }
}
