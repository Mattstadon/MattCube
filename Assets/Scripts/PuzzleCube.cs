using UnityEngine;

public class PuzzleCube : MonoBehaviour
{
    public int currentState = 0;
    [SerializeField] Transform laserOrientationTransform;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] AudioClip[] sfxClips;

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

        AudioClip chosenClip = sfxClips[currentState % sfxClips.Length];

        if (sfxManager != null && chosenClip != null)
        {
            sfxManager.PlaySFX(sfxManager.SFX1);
        }
    }

    public void ResetValues()
    {
        currentState = 0;
        laserOrientationTransform.localRotation = Quaternion.identity;
    }
}
