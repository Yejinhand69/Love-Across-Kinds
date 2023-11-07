using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static string interactObjectName;
    private DialogueTrigger DialogueTrigger;

    private float pressTime;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private bool isSwiping = false;

    private void Awake()
    {
        DialogueTrigger = GetComponent<DialogueTrigger>();
    }

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
                if (!DialogueManager.dialogueActive)
                {
                    interactObjectName = name;

                    DialogueTrigger.StartDialogue();
                }
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //empty
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        //empty
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        //empty
    }

   

}
