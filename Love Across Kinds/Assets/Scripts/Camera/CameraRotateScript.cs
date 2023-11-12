using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraRotateScript : MonoBehaviour
{
    public float sensitivity = -0.05f;
    private Vector3 touchStart;
    private TransportPoint transportPoint;
    public GameObject zoomXinaCamera0;

    private void Start()
    {
        transportPoint = FindObjectOfType<TransportPoint>();
    }

    void Update()
    {
        
        // Check if the dialogue is active; if so, don't allow camera rotation
        if (DialogueManager.dialogueActive)
        {
            return; // Don't allow camera rotation
        }

        // Check for touch input
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                // Record the starting touch position
                touchStart = touch.position;
                //transportPoint.StartSwiping();
            }
            else if (touch.phase == TouchPhase.Moved)
            {

                // Calculate the difference between the current and starting touch positions
                Vector3 touchEnd = touch.position;
                Vector3 delta = touchEnd - touchStart;

                // Rotate the camera based on touch delta (left and right)
                transform.Rotate(Vector3.up * delta.x * sensitivity);
                Debug.Log("Touch screen sensor");
                zoomXinaCamera0.SetActive(false);

                // Update the starting touch position for the next frame
                touchStart = touch.position;
            }

        }
    }
}