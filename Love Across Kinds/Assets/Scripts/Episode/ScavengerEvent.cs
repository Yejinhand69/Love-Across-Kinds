using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerEvent : MonoBehaviour
{
    public GameObject bracelet;
    public static bool isScavengerEvent;
    public GameObject BraceletUI;
    public static bool isFoundBracelet;

    private void Update()
    {
        if(PhaseManager.instance.currentPhase == "PreProduction" && PhaseManager.instance.currentEpisode == 1)
        {
            //Check if ScavengerEvent is started or not
            if (isScavengerEvent && !isFoundBracelet)
            {
                bracelet.SetActive(true);
            }

            //Dialogue associated lines
            if (DialogueManager.instance.currSentenceId == 75)
            {
                //UI of bracelet active
                BraceletUI.SetActive(true);
            }
            else if (DialogueManager.instance.currSentenceId == 78)
            {
                //UI of bracelet deactive
                BraceletUI.SetActive(false);
            }

            //Check if player pressed on the Event Object
            if (EventClick.interactObjectName == bracelet.name)
            {
                if(DialogueManager.instance.currSentenceId == 67)
                {
                    bracelet.SetActive(false);
                    isFoundBracelet = true;
                } 
            }
        }
    }
}
