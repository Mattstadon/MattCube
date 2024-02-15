using UnityEngine;

public class ModelRotator : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation
    private bool isDragging = false; // Flag to check if the user is dragging
    private Vector3 touchStartPosition; // Position where the touch began

    void Update()
    {
        // Check for touch inputs
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // The user starts dragging
                    isDragging = true;
                    touchStartPosition = touch.position;
                    break;

                case TouchPhase.Moved:
                    // The user is dragging
                    if (isDragging)
                    {
                        // Calculate the difference in position
                        float deltaX = touch.deltaPosition.x;// touch.position.x - touchStartPosition.x;
                        float deltaY = touch.deltaPosition.y;// touch.position.y - touchStartPosition.y;

                        // Rotate the object
                        Vector3 rotationDifference = new Vector3(touch.deltaPosition.y, touch.deltaPosition.x, 0);

                        transform.Rotate(-Vector3.up * deltaX);
                        //transform.Rotate(transform.right * deltaY);

                        //transform.rotation *= Quaternion.Euler(rotationDifference);//Quaternion.Lerp(transform.localRotation, transform.localRotation * Quaternion.Euler(rotationDifference), Time.deltaTime * rotationSpeed);
                        //transform.Rotate(deltaX * rotationSpeed * Time.deltaTime, deltaY * rotationSpeed * Time.deltaTime, 0, Space.World);
                    }
                    break;

                case TouchPhase.Ended:
                    // The user stopped dragging
                    isDragging = false;
                    break;
            }
        }
    }
}
