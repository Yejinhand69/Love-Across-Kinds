using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransportPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string sceneToLoad;
    public Animator animator;

    public float delayBeforeLoad = 1.0f;
    private bool isSwiping = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        if (!DialogueManager.dialogueActive && !isSwiping)
        {
            animator.SetTrigger("FadeOut");

            StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isSwiping = false;
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

    public void StartSwiping()
    {
        isSwiping = true;
    }
    public void StopSwiping()
    {
        isSwiping = false;
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }

}
