using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransportPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string sceneToLoad;
    public Animator animator;

    public float delayBeforeLoad = 1.0f;
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
                animator.SetTrigger("FadeOut");
                StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
            }
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
