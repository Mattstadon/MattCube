using UnityEngine;
using UnityEngine.UI;

public class ScanEffect : MonoBehaviour
{
    public Image scanImage; // Assign the Image element in the Inspector
    public float speed = 10f; // Speed of the scan effect
    private bool isScanning = false; // Flag to control the scan effect

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space to trigger the scan effect
        {
            isScanning = !isScanning; // Toggle the scan effect on and off
        }

        if (isScanning)
        {
            // Move the Image element from left to right
            scanImage.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

            // If the Image reaches the right edge of the screen, reset its position to the left
            if (scanImage.transform.position.x > Screen.width)
            {
                scanImage.transform.position = new Vector3(-scanImage.rectTransform.rect.width, scanImage.transform.position.y, 0);
            }
        }
    }
}