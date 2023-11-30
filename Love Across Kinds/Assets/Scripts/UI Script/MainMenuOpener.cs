using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MainMenuOpener : MonoBehaviour
{
    public GameObject CreditPanel;
    public GameObject SettingsPanel;
    public Animator animator;

    public string sceneToLoad;
    public float delayBeforeLoad = 1.0f;

    public static MainMenuOpener instance;


    private void Awake()
    {
        PhaseManager.instance.currentPhase = "MainMenu";

        if(instance== null)
        {
            // This is the first instance of the script, so we set it as the instance
            instance = this;

            // Make sure this object persists between scenes
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OpenCreditPanel()
    {
        if (CreditPanel != null)
        {

            Animator animator = CreditPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openCredit");

                animator.SetBool("openCredit", !isOpen);
            }

        }

    }
    public void OpenSettingsPanel()
    {
        if (SettingsPanel != null)
        {
            
            Animator animator = SettingsPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openSettings");

                animator.SetBool("openSettings", !isOpen);
            }

        }
     
    }

    public void StartGame()
    {
        AudioManager.instance.PlaySFX("Button Press");

        StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
    }

    

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        PhaseManager.instance.currentPhase = "Prologue";
        SceneManager.LoadScene(sceneName);
    }
}
