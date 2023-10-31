using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOpener : MonoBehaviour
{
    public GameObject CreditPanel;
    public GameObject SettingsPanel;
    public GameObject NamingBox;
    public Animator animator;

    public string sceneToLoad;
    public float delayBeforeLoad = 1.0f;

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

        OpenNamingBox();
    }

    public void OpenNamingBox()
    {
        if (NamingBox != null)
        {

            Animator animator = NamingBox.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("isOnNaming");

                animator.SetBool("isOnNaming", !isOpen);
            }

        }
    }

    public void OkToStart()
    {
        if(UserData.instance.playerName != "Player")
        {
            NamingBox.GetComponent<Animator>().SetBool("isOnNaming", false);

            animator.SetTrigger("FadeOut");

            StartCoroutine(LoadSceneWithDelay(sceneToLoad, delayBeforeLoad));
        }
        else
        {
            Debug.Log("Please Enter Your Name");
        }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);
    }
}
