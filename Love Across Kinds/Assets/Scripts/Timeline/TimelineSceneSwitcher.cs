using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TimelineSceneSwitcher : MonoBehaviour
{
    public PlayableDirector timeline; // Reference to your Timeline asset
    public string nextSceneName;      // Name of the scene to load when the Timeline ends

    private void Start()
    {
        // Register a callback to listen for the Timeline's completion event
        timeline.stopped += OnTimelineStopped;
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        if (director == timeline)
        {
            // Load the next scene when the Timeline ends
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogWarning("Next scene name is not set.");
        }
    }
}
