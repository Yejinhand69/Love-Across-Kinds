using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOpener : MonoBehaviour
{
    public GameObject PhonePanel;
    public GameObject SettingPanel;
    public CameraRotateScript cameraRotateScript;

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
}
