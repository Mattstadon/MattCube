using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCube : MonoBehaviour
{
    public int currentState = 0;
    [SerializeField] Transform laserOrientationTransform;

    private void OnMouseDown()
    {
        currentState += 1;
        if (currentState > 7)
        {
            currentState = 0;
        }

        Vector3 targetRotation = laserOrientationTransform.localRotation.eulerAngles;
        targetRotation.y = 45 * currentState;

        laserOrientationTransform.localRotation = Quaternion.Euler(targetRotation);
    }
}
