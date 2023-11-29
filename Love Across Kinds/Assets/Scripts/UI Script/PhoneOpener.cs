using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhoneOpener : MonoBehaviour
{
    //UI stuffs
    [SerializeField] private GameObject AffectionPanel;
    public GameObject SettingPanel;
    public GameObject MessagePanel;
    public GameObject ObjectivePanel;
    public CameraRotateScript cameraRotateScript;

    public void OpenSettingPanel()
    {
        if (SettingPanel != null)
        {
            Animator animator = SettingPanel.GetComponent<Animator>();
            if (animator != null)
            {
                AudioManager.instance.PlaySFX("Button Press");

                bool isOpen = animator.GetBool("openSettings");

                animator.SetBool("openSettings", !isOpen);
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
        Debug.Log("openObjectivePanel");
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
