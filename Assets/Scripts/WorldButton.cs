using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    [SerializeField] UnityEvent eventsToFire;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] float buttonClickVolume = 1f; // Optional volume parameter for the button click sound

    private void OnMouseDown()
    {
        if (sfxManager != null && buttonClickSound != null)
        {
            sfxManager.PlaySFX(buttonClickSound, buttonClickVolume); // Pass the volume parameter
        }

        eventsToFire.Invoke();
    }
}
