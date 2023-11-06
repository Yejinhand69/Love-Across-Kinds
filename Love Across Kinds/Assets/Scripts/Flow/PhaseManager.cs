using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PhaseManager : MonoBehaviour
{
    public int currentPhaseIndex ;

    public int currentEpisode ;

    public string currentPhase;

    public static PhaseManager instance;

    private DialogueTrigger dialogueTrigger;

    public bool isDone;

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

        dialogueTrigger = GetComponent<DialogueTrigger>();

        if(SceneManager.GetActiveScene().name == "Lobby0" && !instance.isDone)
        {
            instance.isDone = true;
            dialogueTrigger.StartDialogue("Player", 62);     
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
}
