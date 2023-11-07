using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadRhythmSync : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe
    public string rhythmGameSceneName = "Rhythm Game"; // Name of the scene you want to load
    private string previousSceneName; // Store the name of the previous scene

    private void Start()
    {
        // Record the name of the current scene as the previous scene
        previousSceneName = SceneManager.GetActiveScene().name;
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
                // Load the 'Rhythm Game' scene asynchronously
                StartCoroutine(LoadRhythmGameAsync());
            }
        }
    }
    IEnumerator LoadRhythmGameAsync()
    {
        // Use SceneManager.LoadSceneAsync to load the scene asynchronously.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(rhythmGameSceneName);

        // Wait for the scene to finish loading.
        while (!asyncLoad.isDone)
        {
            // You can add loading animations or progress updates here if needed.
            yield return null;
        }
        // The 'Rhythm Game' scene has finished loading; now, return to the previous scene.
        SceneManager.LoadScene(previousSceneName);
    }
}
