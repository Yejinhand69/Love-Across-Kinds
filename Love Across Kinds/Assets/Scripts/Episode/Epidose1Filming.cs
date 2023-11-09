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
            switch (DialogueManager.instance.currSentenceId)
            {
                case 2:
                    //SFX - Light
                    //Animation - Lights on
                    break;
                case 4:
                    //SFX
                    break;
                case 5:
                    //Animation - Light focus on GHJ
                    break;
                case 9:
                    //SFX - Crowd cheer and clap
                    break;
                case 14:
                    //SFX - Light
                    //Animation - Light on Xina
                    break;
                case 17:
                    //SFX - Crowd
                    break;
                case 18:
                    //SFX - Light off
                    break;
                case 25:
                    //SFX - Light
                    break;
                case 28:
                    //SFX - Crowd cheer and clap
                    break;
                case 32:
                    //SFX - Light off
                    break;
                case 38:
                    //SFX - Light on
                    break;
                case 42:
                    //SFX - Clap
                    break;
                case 43:
                    //SFX - Light off
                    break;
                case 48:
                    //SFX - Light on
                    break;
                case 49:
                    //SFX - Cheer and Clap
                    break;
                case 51:
                    //SFX - Light off
                    break;
                case 55:
                    //SFX - Light on
                    break;
                case 56:
                    //SFX - Cheer and Clap
                    break;
                case 58:
                    //SFX - Cheer and Clap
                    break;
                case 59:
                    //SFX - Light off
                    break;
                case 62:
                    //SFX - Light on
                    break;
                case 70:
                    //SFX - Crowd oooooo
                    break;
                case 73:
                    //SFX - Light on
                    break;
                case 75:
                    //SFX - Light on
                    break;
                case 77:
                    //SFX - Light off
                    break;
                case 84:
                    //SFX - Light off
                    break;
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
                dialogueTrigger.StartDialogue("Game Host Joe", 317);
            }
        }
        
    }
}
