using UnityEngine;

public class PuzzleCube : MonoBehaviour
{
    public int currentState = 0;
    [SerializeField] Transform laserOrientationTransform;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] AudioClip[] sfxClips;

    private void OnMouseDown()
    {
        laserOrientationTransform.gameObject.SetActive(true);

        currentState += 1;
        if (currentState > 7)
        {
            currentState = -1;
            laserOrientationTransform.gameObject.SetActive(false);
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
        currentState = -1;
        laserOrientationTransform.gameObject.SetActive(false);
        laserOrientationTransform.localRotation = Quaternion.identity;
    }
}
