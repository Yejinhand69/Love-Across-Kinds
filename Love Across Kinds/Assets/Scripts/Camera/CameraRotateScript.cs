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
    public GameObject zoomBeniaCamera0;
    public GameObject zoomFlorineCamera0;
    public GameObject zoomBeniaCamera1pp;
    public GameObject zoomFlorineCamera1pp;
    public GameObject zoomXinaCamera1ft;
    public GameObject zoomBeniaCamera1ft;
    public GameObject zoomFlorineCamera1ft;
    public GameObject zoomXinaCamera1sp;
    public GameObject zoomBeniaCamera1sp;
    public GameObject zoomFlorineCamera1sp;
    public GameObject zoomXinaRecording1pp;
    public GameObject zoomHostRecording1pp;
    public GameObject zoomXinaRecording1fm;
    public GameObject zoomBeniaRecording1fm;
    public GameObject zoomFlorineRecording1fm;

    private void Start()
    {
        transportPoint = FindObjectOfType<TransportPoint>();
    }

    void Update()
    {
        
        // Check if the dialogue is active; if so, don't allow camera rotation
        if (DialogueManager.dialogueActive || UserData.instance.isOnNaming)
        {
            return; // Don't allow camera rotation
        }

        // Check for touch input
        if (Input.touchCount > 0)
        {
            //try kan xia
            zoomXinaCamera0.SetActive(false);
            zoomBeniaCamera0.SetActive(false);
            zoomFlorineCamera0.SetActive(false);
            zoomBeniaCamera1pp.SetActive(false);
            zoomFlorineCamera1pp.SetActive(false);
            zoomXinaCamera1ft.SetActive(false);
            zoomBeniaCamera1ft.SetActive(false);
            zoomFlorineCamera1ft.SetActive(false);
            zoomXinaCamera1sp.SetActive(false);
            zoomBeniaCamera1sp.SetActive(false);
            zoomFlorineCamera1sp.SetActive(false);
            zoomXinaRecording1pp.SetActive(false);
            zoomHostRecording1pp.SetActive(false);
            zoomXinaRecording1fm.SetActive(false);
            zoomBeniaRecording1fm.SetActive(false);
            zoomFlorineRecording1fm.SetActive(false);

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
                //Debug.Log("Touch screen sensor");

                //zoomXinaCamera0.SetActive(false);
                //zoomBeniaCamera0.SetActive(false);
                //zoomFlorineCamera0.SetActive(false);
                //zoomBeniaCamera1pp.SetActive(false);
                //zoomFlorineCamera1pp.SetActive(false);
                //zoomXinaCamera1ft.SetActive(false);
                //zoomBeniaCamera1ft.SetActive(false);
                //zoomFlorineCamera1ft.SetActive(false);
                //zoomXinaCamera1sp.SetActive(false);
                //zoomBeniaCamera1sp.SetActive(false);
                //zoomFlorineCamera1sp.SetActive(false);
                //zoomXinaRecording1pp.SetActive(false);
                //zoomHostRecording1pp.SetActive(false);
                //zoomXinaRecording1fm.SetActive(false);
                //zoomBeniaRecording1fm.SetActive(false);
                //zoomFlorineRecording1fm.SetActive(false);

                // Update the starting touch position for the next frame
                touchStart = touch.position;
            }

        }
    }
}