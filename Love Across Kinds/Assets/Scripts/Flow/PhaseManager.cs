using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class PhaseManager : MonoBehaviour
{
    public int currentPhaseIndex ;

    public int currentEpisode ;

    public string currentPhase;

    public static PhaseManager instance;

    public DialogueTrigger dialogueTrigger;
    public PhoneOpener phoneOpener;

    public bool isDonePrologue;
    public bool isDonePP1;

    private string[] phases = { "Prologue", "PreProduction", "Filming", "FreeTime" };//added prologue phase

    private void Awake()
    {
        // Ensure only one instance of this script exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

        // Load the saved currentPhaseIndex from PlayerPrefs
        //currentPhaseIndex = PlayerPrefs.GetInt("CurrentPhaseIndex", 0);

        phoneOpener = FindObjectOfType<PhoneOpener>();
        dialogueTrigger = GetComponent<DialogueTrigger>();

        if(SceneManager.GetActiveScene().name == "Lobby0" && !instance.isDonePrologue)
        {
            instance.isDonePrologue = true;
            dialogueTrigger.StartDialogue("Player", 62);     
        }

        if (currentPhase == "PreProduction" && currentEpisode == 1 && !instance.isDonePP1)
        {
            
            GameObject.Find("SenderName").GetComponent<TextMeshProUGUI>().text = DialogueManager.instance.datas[1].name;
            GameObject.Find("Message").GetComponent<TextMeshProUGUI>().text = DialogueManager.instance.datas[1].sentence;

            AudioManager.instance.PlaySFX("Notification 2");

            dialogueTrigger.StartDialogue(" ", 0);
            Debug.Log("Dialogue Start 0");
            
        }
    }

    private void Update()
    {
        if (currentPhase == "PreProduction" && currentEpisode == 1 && !instance.isDonePP1)
        {
            while (DialogueManager.dialogueActive)
            {
                continue;
            }
            
            StartCoroutine(ShowPhoneMessage());
            instance.isDonePP1 = true;
        }
    }

    private void UpdatePhaseText()
    {
        currentPhase = phases[currentPhaseIndex];
        //Debug.Log("Current Phase: " + currentPhase);
        DataProcessor.instance.ProcessDialogueData();

        // Save the currentPhaseIndex to PlayerPrefs
        //PlayerPrefs.SetInt("CurrentPhaseIndex", currentPhaseIndex);
        //PlayerPrefs.Save();

        // You can update a UI text field or any other display with the currentPhase value.
    }

    public void ChangePhase()
    {
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Length;
        UpdatePhaseText();
        AudioManager.instance.PlayBGM();
    }

    IEnumerator ShowPhoneMessage()
    {
        yield return new WaitForSeconds(0.5f);
        while (DialogueManager.dialogueActive)
        {
            yield return null;
        }

        phoneOpener.OpenPhone();

        yield return new WaitForSeconds(0.5f);
        
        phoneOpener.OpenMessagePanel();

        while (phoneOpener.PhonePanel.GetComponent<Animator>().GetBool("openPhone"))
        {
            yield return null;
        }

        if (phoneOpener.PhonePanel.GetComponent<Animator>().GetBool("openPhone") == false)
        {
            phoneOpener.OpenMessagePanel();
        }

        dialogueTrigger.StartDialogue(" ", 2);
    }
}
