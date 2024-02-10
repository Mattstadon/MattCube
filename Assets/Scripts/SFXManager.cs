using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip SFX1;
    public AudioClip SFX2;
    public AudioClip SFX3;
    public AudioClip SFX4;
    public AudioClip SFX5;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        SFXSource.PlayOneShot(clip, volume);
    }
}
