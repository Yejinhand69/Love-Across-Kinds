using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserData : MonoBehaviour
{
    public static UserData instance;

    public GameObject NamingBox;

    public  bool isOnNaming;

    public string playerName = "Player";

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        NamingBox = GameObject.Find("NamingBox");
    }

    public void FieldSelected()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
 
    public void UserInput(string name)
    { 
        playerName = name;
    }

    public void OpenNamingBox()
    {
        if (NamingBox != null)
        {
            isOnNaming = true;

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
        if (instance.playerName != "Player")
        {
            NamingBox.GetComponent<Animator>().SetBool("isOnNaming", false);
            isOnNaming = false;
        }
        else
        {
            Debug.Log("Please Enter Your Name");
        }
    }
}
