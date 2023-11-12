using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ep00 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float pressTime;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private bool isSwiping = false;
    public GameObject mainCamera;
    public GameObject zoomXinaCamera0;
    public Animator animator;
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isSwiping)
        {
            pressTime = Time.time;
        }

    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!isSwiping)
        {
            float releaseTime = Time.time;
            float pressDuration = releaseTime - pressTime;

            if (pressDuration <= swipeThreshold)
            {
                
                mainCamera.SetActive(false);
                zoomXinaCamera0.SetActive(true);
                animator.SetTrigger("Zoom xina lobby0");
                
            }
        }
    }

    

}