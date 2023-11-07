using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;
    public bool countDown;
    public static bool situation;

    public BeatScroller theBS;

    public static GameManager instance;

    private float noteCount;
    private float totalCountNote;
    private float percentageCount;
   
    public Text scoreText;

    public int currentScore;
    public int scorePerNote = 25;

    public GameObject winResultsScreen;
    public GameObject loseResultsScreen;
    public GameObject inGameUI;

    public Text finalScoreText;

    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;

    public AudioSource readyFX;

    // Start is called before the first frame update
    void Start()
    {

        totalCountNote = theBS.totalNotes;
        Debug.Log("TotalNote: " + totalCountNote);
        startPlaying = true;
        countDown = true;

        scoreText.text = "0";
        StartCoroutine(CountSequence());
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying && !countDown)
        {
            startPlaying = true;
            theBS.hasStarted = true;
            theMusic.Play();
        }
        else
        {
            if (!theMusic.isPlaying && !winResultsScreen.activeInHierarchy && !loseResultsScreen.activeInHierarchy && !countDown)
            {
                if (percentageCount >= 70)
                {
                    situation = true;
                    winResultsScreen.SetActive(true);
                    inGameUI.SetActive(false);
                    finalScoreText.text = "Score: " + currentScore;
                }
                else if(percentageCount <70)
                {
                    situation = false;
                    loseResultsScreen.SetActive(true);
                    inGameUI.SetActive(false);
                    finalScoreText.text = "Score: " + currentScore;
                }
                
            }
        }
        percentageCount = (noteCount / totalCountNote) *100;
    }

    public void NoteHit()
    {
        currentScore += scorePerNote;
        scoreText.text = currentScore.ToString();
        noteCount += 1;

    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        countDown3.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown3.SetActive(false);
        countDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown2.SetActive(false);
        countDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        countDown1.SetActive(false);
        startPlaying = false;
        countDown = false;
    }
}
