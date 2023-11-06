using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epidose1Filming : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    void Start()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();

        dialogueTrigger.StartDialogue("Game Host Joe", 0);
        //Animation 1
    }

    
    void Update()
    {
        switch(DialogueManager.instance.currSentenceId)
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
        }
    }
}
