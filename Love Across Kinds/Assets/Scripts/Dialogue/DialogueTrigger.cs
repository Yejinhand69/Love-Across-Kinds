using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int startingSentenceID;

    public void StartDialogue()
    {
        DialogueManager.instance.OpenDialogue(name, startingSentenceID);
    }

    public void StartDialogue(string name, int startID)
    {
        DialogueManager.instance.OpenDialogue(name, startID);
    }
}
