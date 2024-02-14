using UnityEngine;
using System.Collections;

public class CameraBackground : MonoBehaviour
{
    public int cameraIndex = 1; // Front camera is usually index  0, rear camera is  1
    public Renderer meshrenderer; // Assign the Renderer component of the plane or quad

    private WebCamTexture webCamTexture;

    IEnumerator Start()
    {
        // Request permissions for camera usage
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            // Check if there are any cameras available
            if (WebCamTexture.devices.Length > 0)
            {
                // Use the first available camera
                webCamTexture = new WebCamTexture(WebCamTexture.devices[cameraIndex].name);

                // Set the camera to play automatically
                webCamTexture.Play();

                // Apply the camera texture to the Renderer
                meshrenderer.sharedMaterial.mainTexture = webCamTexture;
            }
            else
            {
                Debug.LogError("No camera detected.");
            }
        }
        else
        {
            Debug.LogError("Permission denied to access the camera.");
        }
    }

    private void OnDestroy()
    {
        if (webCamTexture != null)
        {
            webCamTexture.Stop();
        }
    }
}
