using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;

    public bool startPlaying;
    public bool countDown;

    public BeatScroller theBS;

    public static GameManager instance;

    private float totalNotes;
    public float highScore;

    public Text scoreText;

    public int currentScore;
    public int scorePerNote = 25;

    public GameObject resultsScreen;
    public GameObject inGameUI;

    public Text finalScoreText;

    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;

    public AudioSource readyFX;

    // Start is called before the first frame update
    void Start()
    {
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
            if (!theMusic.isPlaying && !resultsScreen.activeInHierarchy && !countDown)
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
