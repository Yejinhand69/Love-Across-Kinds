using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private int startingSentenceID;

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(name, startingSentenceID);
    }
}