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

    

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
