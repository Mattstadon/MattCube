using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    [SerializeField] UnityEvent eventsToFire;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] float buttonClickVolume = 1f;

    private void OnMouseDown()
    {
        if (sfxManager != null && buttonClickSound != null)
        {
            sfxManager.PlaySFX(buttonClickSound, buttonClickVolume);
        }

        eventsToFire.Invoke();
    }
}
