using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera targetCamera; // Reference to the camera you want to follow
    public float smoothSpeed = 0.125f; // Adjust this value to control the smoothness of the follow

    void LateUpdate()
    {
        if (targetCamera != null)
        {
            // Follow the position
            Vector3 desiredPosition = targetCamera.transform.position;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            // Follow the rotation
            Quaternion desiredRotation = targetCamera.transform.rotation;
            Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, smoothSpeed);
            transform.rotation = smoothedRotation;
        }
    }
}
