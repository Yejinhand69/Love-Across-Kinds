using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;

    public BeatScroller theBS;

    public static GameManager instance;

    private float totalNotes;
    public float highScore;

    public Text scoreText;

    public int currentScore;
    public int scorePerNote = 100;

    public GameObject resultsScreen;
    public GameObject inGameUI;

    public Text finalScoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                theMusic.Play();
            }
        }
        else
        {
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy)
            {
                resultsScreen.SetActive(true);
                inGameUI.SetActive(false);
                finalScoreText.text = "Score: " + currentScore;
            }
        }
    }

    public void NoteHit()
    {
        currentScore += scorePerNote;
        scoreText.text = currentScore.ToString();
    }
}
