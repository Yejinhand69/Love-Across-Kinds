using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class TimingB : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    [SerializeField] public bool chooseLeastScoreAnswer = false;
    

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

        if(remainingTime <= 0)
        {
            chooseLeastScoreAnswer = true;
            
        }
        
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = "Timer: " + string.Format("{0:00}:{1:00}", minutes, second);
    }
}
