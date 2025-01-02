using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GoOutsideBedroom : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    //public GameObject sleepPanel;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    private string currentSceneName;
    public GameObject transportPoint;

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        if(currentSceneName == "LivingFloor1")
        {
            if(transportPoint != null)
            {
                transportPoint.SetActive(false);
            }
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
                if (currentSceneName == "LivingFloor0")
                {
                    Camera.main.transform.position = new Vector3(0f, 0.5f, -7.06f);
                    transportPoint.SetActive(true);
                }
                if (currentSceneName == "LivingFloor1")
                {
                    Camera.main.transform.position = new Vector3(0f, 0.92f, -7.06f);
                    transportPoint.SetActive(true);
                }
               
                //OpenSleepPanel();
                //animator.SetTrigger("FadeOut");
                //StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
            }
        }
    }

  


}
