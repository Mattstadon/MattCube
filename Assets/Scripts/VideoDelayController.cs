using UnityEngine;
using UnityEngine.Video;
using System.Collections; // Add this line

public class VideoDelayController : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer; // Reference to the VideoPlayer component
    [SerializeField] private float delay = 5f; // Delay in seconds before playing the video

    private void OnEnable()
    {
        // Start the coroutine when the object is enabled
        StartCoroutine(PlayVideoWithDelay());
    }

    private IEnumerator PlayVideoWithDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Play the video
        if (videoPlayer != null)
        {
            videoPlayer.Play();
        }
    }
}
