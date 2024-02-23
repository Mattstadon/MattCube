using UnityEngine;

public class AudioReactivity : MonoBehaviour
{
    public AudioSource audioSource; // Reference to the AudioSource component
    public float reactivityScale = 1f; // Scale factor for the reactivity
    public float colorReactivityScale = 1f; // Scale factor for the color reactivity

    private float[] audioSpectrum; // Array to hold the audio spectrum data
    private Material material; // Material of the GameObject

    void Start()
    {
        // Ensure the AudioSource component is attached to the GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Initialize the audio spectrum array with a fixed size of  1024
        audioSpectrum = new float[1024];

        // Get the Material of the GameObject
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Check if the audio is playing
        if (audioSource.isPlaying)
        {
            // Get the audio spectrum data
            audioSource.GetSpectrumData(audioSpectrum, 0, FFTWindow.BlackmanHarris);

            // Calculate the average frequency value
            float averageFrequency = 0;
            for (int i = 0; i < audioSpectrum.Length; i++)
            {
                averageFrequency += audioSpectrum[i];
            }
            averageFrequency /= audioSpectrum.Length;

            // React to the audio by changing the scale of the GameObject
            transform.localScale = new Vector3(averageFrequency * reactivityScale, averageFrequency * reactivityScale, averageFrequency * reactivityScale);

            // React to the audio by changing the color of the GameObject
            // This example uses a gradient color scheme based on the average frequency
            float colorValue = Mathf.Clamp01(averageFrequency * colorReactivityScale);
            // Calculate the color based on the gradient
            Color color = Color.Lerp(Color.red, Color.blue, colorValue);
            // Add a green component based on the average frequency
            color.g = Mathf.Clamp01(0.5f + 0.5f * colorValue);
            // Add a red component based on the average frequency
            color.r = Mathf.Clamp01(0.5f + 0.5f * (1 - colorValue));
            material.color = color;
        }
    }
}
