using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadRhythmSync : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f;
    public string rhythmGameSceneName = "Rhythm Game";
    private Scene previousScene; // Store the previous scene

    private void Start()
    {
        // Record the current scene as the previous scene
        previousScene = SceneManager.GetActiveScene();
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

        // The 'Rhythm Game' scene has finished loading; unload it and return to the previous scene.
        SceneManager.UnloadSceneAsync(rhythmGameSceneName);
        SceneManager.SetActiveScene(previousScene);
    }
}