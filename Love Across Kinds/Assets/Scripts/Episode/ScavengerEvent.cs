using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScavengerEvent : MonoBehaviour
{
    public GameObject bracelet;
    public static bool isScavengerEvent;

    private void Update()
    {
        if(PhaseManager.instance.currentPhase == "PreProduction" && PhaseManager.instance.currentEpisode == 1)
        {
            //Check if ScavengerEvent is started or not
            if (isScavengerEvent)
            {
                Debug.Log("setActive");
                bracelet.SetActive(true);
            }

            //Dialogue associated lines
            if (DialogueManager.instance.currSentenceId == 75)
            {
                //UI of bracelet active
            }
            else if (DialogueManager.instance.currSentenceId == 78)
            {
                //UI of bracelet deactive
            }

            //Check if player pressed on the Event Object
            if (EventClick.interactObjectName == bracelet.name)
            {
                bracelet.SetActive(false);
                Destroy(bracelet);
            }
        }
    }
}