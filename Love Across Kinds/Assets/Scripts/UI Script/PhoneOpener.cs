using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOpener : MonoBehaviour
{
    public GameObject PhonePanel;


    public void OpenPhone()
    {
        if (PhonePanel != null)
        {
            //bool isActive = Panel.activeSelf;//added
            //Panel.SetActive(!isActive);//added

            Animator animator = PhonePanel.GetComponent<Animator>();
            if (animator != null)
            {
                bool isOpen = animator.GetBool("openPhone");

                animator.SetBool("openPhone", !isOpen);
            }

        }

    }
}
