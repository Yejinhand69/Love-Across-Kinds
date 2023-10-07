using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class EventClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public string sceneToLoad;
    public Animator animator;

    public static string interactObjectName;

    public float delayBeforeLoad = 1.0f;

    private DialogueTrigger DialogueTrigger;

    private void Awake()
    {
        DialogueTrigger = GetComponent<DialogueTrigger>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //animator.SetTrigger("FadeOut");

        //StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));

        interactObjectName = name;

        DialogueTrigger.StartDialogue();
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

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }

}
