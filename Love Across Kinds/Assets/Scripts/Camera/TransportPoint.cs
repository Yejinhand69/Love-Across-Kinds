using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TransportPoint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject TransportPanel;
    //public string sceneToLoad;
    public Animator animator;

    public float delayBeforeLoad = 1.0f;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe

    public static TransportPoint instance;
    private void Awake()
    {
        // Ensure only one instance of this script exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Destroy(gameObject);
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
                OpenTransportPanel();
                
               
                //StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
            }
        }
    }
    public void OpenTransportPanel()
    {
        if (TransportPanel != null)
        {

            Animator animator = TransportPanel.GetComponent<Animator>();
            if (animator != null)
            {
                //AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openTransportPanel");

                animator.SetBool("openTransportPanel", !isOpen);
            }

        }
    }

    public void LoadLobby0()
    {
        StartCoroutine(LoadSceneWithDelay("Lobby0",delayBeforeLoad));
        //animator.SetTrigger("FadeOut");
        //SceneManager.LoadScene("Lobby0");
        
    }
    public void LoadRecording0()
    {
        StartCoroutine(LoadSceneWithDelay("Recording0", delayBeforeLoad));
    }

    public void LoadLivingFloor0()
    {
        StartCoroutine(LoadSceneWithDelay("LivingFloor0", delayBeforeLoad));
    }

    public void LoadLobby1()
    {
        StartCoroutine(LoadSceneWithDelay("Lobby1", delayBeforeLoad));
    }
    public void LoadRecording1()
    {
        StartCoroutine(LoadSceneWithDelay("Recording1", delayBeforeLoad));
    }
    public void LoadLivingFloor1()
    {
        StartCoroutine(LoadSceneWithDelay("LivingFloor1", delayBeforeLoad));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("FadeIdle");
       
    }
}
