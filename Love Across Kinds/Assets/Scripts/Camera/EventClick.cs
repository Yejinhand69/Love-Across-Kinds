using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static string interactObjectName;
    public static Animator interactObjAnim;
    private DialogueTrigger DialogueTrigger;

    private float pressTime;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private bool isSwiping = false;

    public GameObject mainCamera;
   

    private void Awake()
    {
        DialogueTrigger = GetComponent<DialogueTrigger>();
        
        
    }

    private void Update()
    {
        if(DialogueManager.dialogueActive == false)
        {
            
            mainCamera.SetActive(true);
            
        }
        if (DialogueManager.dialogueActive == true)
        {
            
            mainCamera.SetActive(false);
        }
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
                    Debug.Log(name);
                    interactObjectName = name;

                    if (TryGetComponent(out Animator anim))
                    {
                        interactObjAnim = anim;
                    }

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
