using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneOpener : MonoBehaviour
{
    //UI stuffs
    [SerializeField] private GameObject AffectionPanel;
    public GameObject PhoneButton;
    public GameObject PhonePanel;
    public GameObject SettingPanel;
    public GameObject MessagePanel;
    public GameObject ObjectivePanel;
    public CameraRotateScript cameraRotateScript;

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Episode 0")
        {
            PhoneButton.SetActive(false);
        }
        else
        {
            PhoneButton.SetActive(true);
        }
    }

    public void OpenPhone()
    {
        if (PhonePanel != null)
        {
            //bool isActive = Panel.activeSelf;//added
            //Panel.SetActive(!isActive);//added
            //cameraRotateScript.FreezeCamera();
            Animator animator = PhonePanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openPhone");

                animator.SetBool("openPhone", !isOpen);
            }
            
        }
    }
   
    public void OpenSettingPanel()
    {
        if (SettingPanel != null)
        {
            //bool isActive = Panel.activeSelf;//added
            //Panel.SetActive(!isActive);//added

            Animator animator = SettingPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openSettingPanel");

                animator.SetBool("openSettingPanel", !isOpen);
            }
        }
    }

    public void OpenAffectionWindow()
    {
        if (AffectionPanel != null)
        {
            Animator animator = AffectionPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openAffectionPanel");

                animator.SetBool("openAffectionPanel", !isOpen);
            }
        }
    }

    public void OpenMessagePanel()
    {
        if (MessagePanel != null)
        { 
            Animator animator = MessagePanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("isOpenMessage");

                animator.SetBool("isOpenMessage", !isOpen);
            }
        }
    }

    public void OpenObjectiveWindow()
    {
        if (ObjectivePanel != null)
        {
            Animator animator = ObjectivePanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openObjectivePanel");

                animator.SetBool("openObjectivePanel", !isOpen);
            }
        }
    }
}
