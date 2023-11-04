using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int currentPhaseIndex ;

    public int currentEpisode ;

    public string currentPhase;

    public static PhaseManager instance;

    private DialogueTrigger dialogueTrigger;

    public bool isDone;

    public GameObject sleepPanel;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe

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
            Destroy(gameObject);
        }

        // Load the saved currentPhaseIndex from PlayerPrefs
        //currentPhaseIndex = PlayerPrefs.GetInt("CurrentPhaseIndex", 0);

        dialogueTrigger = GetComponent<DialogueTrigger>();

        if(SceneManager.GetActiveScene().name == "Lobby0" && !instance.isDone)
        {
            instance.isDone = true;
            dialogueTrigger.StartDialogue("Player", 62);     
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

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
