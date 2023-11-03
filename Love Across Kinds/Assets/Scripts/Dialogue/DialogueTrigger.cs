using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int firstAttempSentenceID;
    [SerializeField] private int repeatAttempSentenceID;
    public static int attemp = 0;

    public void StartDialogue()
    {
        //Check number of attemps of each character
        if (name == "Xina")
        {
            attemp = DialogueManager.instance.XinaAttemp;
        }
        else if (name == "Benia")
        {
            attemp = DialogueManager.instance.BeniaAttemp;
        }
        else if (name == "Florine")
        {
            attemp = DialogueManager.instance.FlorineAttemp;
        }

        //Call dialogue method
        if (attemp == 0)
        {
            DialogueManager.instance.OpenDialogue(name, firstAttempSentenceID);
            attemp++;
        }
        else
        {
            DialogueManager.instance.OpenDialogue(name, repeatAttempSentenceID);
        }

        //Update attemps of each character
        if (name == "Xina")
        {
            DialogueManager.instance.XinaAttemp = attemp;
        }
        else if (name == "Benia")
        {
            DialogueManager.instance.BeniaAttemp = attemp;
        }
        else if (name == "Florine")
        {
            DialogueManager.instance.FlorineAttemp = attemp;
        }
    }

    public void StartDialogue(string name, int startID)
    {
        DialogueManager.instance.OpenDialogue(name, startID);
    }
}
