using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Animator animator;

    public float delayBeforeLoad = 1.0f;
    private float pressTime;
    private bool isSwiping = false;
    public float swipeThreshold = 0.2f; // Adjust this threshold to your preference for distinguishing a tap from a swipe

    public void LoadLobby0()
    {
        StartCoroutine(LoadSceneWithDelay("Lobby0", delayBeforeLoad));

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
