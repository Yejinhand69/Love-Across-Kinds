using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Timing : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;

    public GameObject lose;

    public GameControllerScript gameControllerScript;

    void Update()
    {
        if(remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if(remainingTime <= 0)
        {
            remainingTime = 0;
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, second);

        if(remainingTime == 0 && gameControllerScript.cannotWin == true) 
        {
            //SceneManager.LoadScene("Matching pair Lose");
            lose.SetActive(true);
            GameControllerScript.situation = false;
        }
    }
}
