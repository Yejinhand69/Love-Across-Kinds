using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private float pressDuration;


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
            pressDuration = releaseTime - pressTime;
            if (pressDuration <= swipeThreshold)
            {
                // Check if the object you clicked/touched has the "phase changer" tag
                if (gameObject.CompareTag("LobbyDoor"))
                {
                    Camera.main.transform.position = new Vector3(0.0f, 0.5f, -7.06f);
                }
                if (gameObject.CompareTag("DiningRoomDoor"))
                {
                    Camera.main.transform.position = new Vector3(6.08f, 0.5f, -14.23f);
                }
                if (gameObject.CompareTag("PoolDoor"))
                {
                    Camera.main.transform.position = new Vector3(15.668f, 0.5f, 14.95f);
                }
            }

        }
    }

}
