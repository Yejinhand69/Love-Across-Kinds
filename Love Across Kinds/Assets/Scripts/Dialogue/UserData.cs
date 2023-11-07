using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserData : MonoBehaviour
{
    public static UserData instance;

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
    }

    public void FieldSelected()
    {
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
 
    public void UserInput(string name)
    { 
        playerName = name;
    }
}
