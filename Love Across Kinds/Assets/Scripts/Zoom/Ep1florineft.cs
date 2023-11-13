using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ep1florineft : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float pressTime;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private bool isSwiping = false;
    public GameObject mainCamera;
    public GameObject zoomFlorineCamera1ft;
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
                zoomFlorineCamera1ft.SetActive(true);
                animator.SetTrigger("Zoom florine lobby1ft");

            }
        }
    }



}