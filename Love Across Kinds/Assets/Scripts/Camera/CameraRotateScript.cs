using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    public float sensitivity = -0.2f;
    private Vector3 touchStart;
    private Vector3 touchEnd;

    private float rotationY = 0.0f; // Current camera Y rotation

    // Define the limits for left and right rotation (in degrees)
    public float minRotationY = -90.0f;
    public float maxRotationY = 90.0f;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Record the starting touch position
                touchStart = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                // Calculate the difference between the current and starting touch positions
                touchEnd = touch.position;
                Vector3 delta = touchEnd - touchStart;

                // Rotate the camera based on touch delta (only left and right)
                rotationY += delta.x * sensitivity;
                rotationY = Mathf.Clamp(rotationY, minRotationY, maxRotationY);

                transform.rotation = Quaternion.Euler(0, rotationY, 0);

                // Update the starting touch position for the next frame
                touchStart = touch.position;
            }
        }
    }
}
