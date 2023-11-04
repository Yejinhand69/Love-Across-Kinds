using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject sleepPanel;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe

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
                OpenSleepPanel();
                //animator.SetTrigger("FadeOut");
                //StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
            }
        }
    }
    public void OpenSleepPanel()
    {
        if (sleepPanel != null)
        {

            Animator animator = sleepPanel.GetComponent<Animator>();
            if (animator != null)
            {
                //AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openSleepPanel");

                animator.SetBool("openSleepPanel", !isOpen);
            }

        }
    }
}
