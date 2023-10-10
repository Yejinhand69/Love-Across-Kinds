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

    private void Awake()
    {
        DialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      
        if (!DialogueManager.dialogueActive)
        {
            interactObjectName = name;

            DialogueTrigger.StartDialogue();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {

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
