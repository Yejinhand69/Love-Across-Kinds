using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuOpener : MonoBehaviour
{
    public GameObject CreditPanel;
    public GameObject SettingsPanel;
    

    public void OpenCreditPanel()
    {
        if (CreditPanel != null)
        {

            Animator animator = CreditPanel.GetComponent<Animator>();
            if (animator != null)
            {
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
                bool isOpen = animator.GetBool("openSettings");

                animator.SetBool("openSettings", !isOpen);
            }

        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("DevScene Ervin");
    }
}
