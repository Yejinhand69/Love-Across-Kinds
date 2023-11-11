using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int firstAttempSentenceID;
    public int repeatAttempSentenceID;
    public static int attemp = 0;
    private Animator anim;

    private void Start()
    {
        TryGetComponent<Animator>(out anim);
    }

    private void Update()
    {
        if(anim != null)
        {
            if (DialogueManager.dialogueActive)
            {
                anim.SetBool("DialogueActive", true);
            }
            else
            {
                anim.SetBool("DialogueActive", false);
            }
        }
    }

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
        else if(name == "Game Host Joe")
        {
            attemp = DialogueManager.instance.GHJoeAttemp;
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
            attemp++;
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
        else if (name == "Game Host Joe")
        {
            DialogueManager.instance.GHJoeAttemp = attemp;
        }
    }

    public void StartDialogue(string name, int startID)
    {
        DialogueManager.instance.OpenDialogue(name, startID);
    }
}
