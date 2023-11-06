using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringB : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int maxScore;
    public int minScore;

    void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void RemoveScore(int newScore) 
    {  
        score -= newScore; 
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        UpdateScore();

        if(score >= maxScore)
        {
            score = maxScore;
        }

        if (score <= minScore)
        {
            score = minScore;
        }
    }
}
