using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    public Material laserMaterial;
    public float maxDistance = 1000f;
    public float laserWidth = 0.1f;
    public AudioClip laserSound; // Laser sound effect
    public float soundVolume = 1f; // Volume for the laser sound

    private LineRenderer lineRenderer;
    private AudioSource audioSource;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        lineRenderer.material = laserMaterial;
        lineRenderer.startWidth = laserWidth;
        lineRenderer.endWidth = laserWidth;
    }

    private void Update()
    {
        // Set the starting position of the laser
        lineRenderer.SetPosition(0, transform.position);

        // Perform a raycast to determine the endpoint of the laser
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
        {
            // If the raycast hits an object, set the end position to the hit point
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // If nothing is hit, extend the laser to its maximum distance
            lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
        }

        // Play the laser sound effect
        if (!audioSource.isPlaying && laserSound != null)
        {
            audioSource.clip = laserSound;
            audioSource.volume = soundVolume;
            audioSource.Play();
        }
    }
}


