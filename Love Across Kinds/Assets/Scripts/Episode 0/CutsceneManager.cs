using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private DialogueTrigger trigger;
    private Animator anim;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        trigger = GetComponent<DialogueTrigger>();
        anim = GetComponent<Animator>();

        StartCoroutine(DelayTriggerDialogue());
    }

    private void Update()
    {
        if (dialogueManager.currSentenceId == 12)
        {
            anim.SetTrigger("1to2");
        }

        if (dialogueManager.currSentenceId == 26 && !(DialogueManager.dialogueActive))
        {
            anim.SetTrigger("2to3");
            StartCoroutine(PlayPhoneRinging());
        }

        if(dialogueManager.currSentenceId == 60 && !(DialogueManager.dialogueActive))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            AudioManager.instance.currentPhase = "PreProduction";
            AudioManager.instance.currentEpisode = 1;
        }
    }

    IEnumerator DelayTriggerDialogue()
    {
        yield return new WaitForSeconds(1.5f);
        trigger.StartDialogue();
    }

    IEnumerator PlayPhoneRinging()
    {
        yield return new WaitForSeconds(4f);
        AudioManager.instance.PlaySFX("Together Succesfully");
        yield return new WaitForSeconds(2f);
        trigger.StartDialogue("???", 27);
    }
}
