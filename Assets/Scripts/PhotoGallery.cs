using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PhotoGallery : MonoBehaviour
{
    public GameObject imagePrefab; // Assign this in the Inspector
    public Transform contentPanel; // Assign this in the Inspector
    public string imagesFolderPath = "Images/"; // Path to your images folder

    void Start()
    {
        LoadImages();
    }

    void LoadImages()
    {
        // Load all images from the specified folder
        Sprite[] sprites = Resources.LoadAll<Sprite>(imagesFolderPath);

        foreach (Sprite sprite in sprites)
        {
            // Instantiate the image prefab
            GameObject imageObject = Instantiate(imagePrefab, contentPanel);

            // Set the image sprite
            Image imageComponent = imageObject.GetComponent<Image>();
            imageComponent.sprite = sprite;
        }
    }
}
