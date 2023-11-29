using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epidose1Filming : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    public GameObject Xina;
    public GameObject Benia;
    public GameObject Florine;

    public static int XinaRepeatID;
    public static int BeniaRepeatID;
    public static int FlorineRepeatID;

    private bool isTalkXina;
    private bool isTalkBenia;
    private bool isTalkFlorine;

    private bool isEndFilm;

    public static bool isPlayedSFX;

    void Start()
    {
        if(PhaseManager.instance.currentPhase == "Filming" && PhaseManager.instance.currentEpisode == 1)
        {
            dialogueTrigger = GetComponent<DialogueTrigger>();

            dialogueTrigger.StartDialogue("Game Host Joe", 0);
            //Animation 1

            XinaRepeatID = 0;
            BeniaRepeatID = 0;
            FlorineRepeatID = 0;
        }  
    }

    
    void Update()
    {
        if (PhaseManager.instance.currentPhase == "Filming" && PhaseManager.instance.currentEpisode == 1)
        {
            if (!isPlayedSFX)
            {
                switch (DialogueManager.instance.currSentenceId)
                {
                    case 1:
                        //SFX - Light
                        AudioManager.instance.PlaySFX("Spotlight On");
                        //Animation - Lights on
                        break;
                    case 3:
                        //SFX - Light turn on at once
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 4:
                        //Animation - Light focus on GHJ
                        break;
                    case 8:
                        //SFX - Crowd cheer and clap
                        AudioManager.instance.PlaySFX("Crowd Ooooo");
                        AudioManager.instance.PlaySFX("Clap");
                        break;
                    case 13:
                        //SFX - Light
                        AudioManager.instance.PlaySFX("Spotlight On");
                        //Animation - Light on Xina
                        break;
                    case 16:
                        //SFX - Crowd cheer and clap
                        AudioManager.instance.PlaySFX("short-crowd-cheer-6713");
                        break;
                    case 17:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 24:
                        //SFX - Light
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 27:
                        //SFX - Crowd cheer and clap
                        AudioManager.instance.PlaySFX("short-crowd-cheer-6713");
                        break;
                    case 31:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 37:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 41:
                        //SFX - Clap
                        AudioManager.instance.PlaySFX("Clap");
                        break;
                    case 42:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 47:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 48:
                        //SFX - Cheer and Clap
                        AudioManager.instance.PlaySFX("short-crowd-cheer-6713");
                        break;
                    case 50:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 54:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 55:
                        //SFX - Cheer and Clap
                        AudioManager.instance.PlaySFX("short-crowd-cheer-6713");
                        break;
                    case 57:
                        //SFX - Cheer and Clap
                        AudioManager.instance.PlaySFX("short-crowd-cheer-6713");
                        break;
                    case 58:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 61:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 69:
                        //SFX - Crowd oooooo
                        AudioManager.instance.PlaySFX("Crowd Ooooo");
                        break;
                    case 72:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 74:
                        //SFX - Light on
                        AudioManager.instance.PlaySFX("Spotlight On");
                        break;
                    case 76:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                    case 83:
                        //SFX - Light off
                        AudioManager.instance.PlaySFX("Spotlight Off");
                        break;
                }

                isPlayedSFX = true;
            }
            if (XinaRepeatID != 0)
            {
                Xina.GetComponent<DialogueTrigger>().repeatAttempSentenceID = XinaRepeatID;
                isTalkXina = true;
            }

            if (BeniaRepeatID != 0)
            {
                Benia.GetComponent<DialogueTrigger>().repeatAttempSentenceID = BeniaRepeatID;
                isTalkBenia = true;
            }

            if (FlorineRepeatID != 0)
            {
                Florine.GetComponent<DialogueTrigger>().repeatAttempSentenceID = FlorineRepeatID;
                isTalkFlorine = true;
            }

            if ( ( (isTalkXina && isTalkBenia) || (isTalkBenia && isTalkFlorine) || (isTalkFlorine && isTalkXina) ) && !isEndFilm)
            {
                isEndFilm = true;
                StartCoroutine(EndingDialogue());
            }
        }
        
    }

    IEnumerator EndingDialogue()
    {
        yield return new WaitForSeconds(1f);
        dialogueTrigger.StartDialogue("Game Host Joe", 317);
        yield return new WaitForSeconds(0.5f);
    }
}
