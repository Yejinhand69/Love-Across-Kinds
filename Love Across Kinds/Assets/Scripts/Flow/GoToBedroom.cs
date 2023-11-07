using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoToBedroom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    //public GameObject sleepPanel;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe

    private DialogueTrigger dialogueTrigger;
    public GameObject transportPoint;

    private void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
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
                dialogueTrigger.StartDialogue();
                StartCoroutine(CheckDialogueActive());
                //OpenSleepPanel();
                //animator.SetTrigger("FadeOut");
                //StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
            }
        }
    }

    IEnumerator CheckDialogueActive()
    {
        yield return new WaitForSeconds(0.5f);

        while (DialogueManager.dialogueActive)
        {
            yield return null;
        }

        Camera.main.transform.position = new Vector3(0.0f, 4.33f, -7.06f);
        transportPoint.SetActive(false);
    }
   
    
}
