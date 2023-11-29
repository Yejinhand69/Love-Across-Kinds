using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    public GameManager gmMngr;
    public bool wLSituation;
    public string phases;
    public int episode;
    private DialogueTrigger dialogueTrigger;
    public GameObject dlgTrgr;
    //public GameObject phaseMngr;
    private PhaseManager instance;

    void Start()
    {
        instance = PhaseManager.instance;

        if (dlgTrgr != null)
        {
            dialogueTrigger = dlgTrgr.GetComponent<DialogueTrigger>();
        }
        else
        {
            Debug.LogWarning("dlgTrgr is not assigned. Make sure to assign it in the Inspector.");
        }

        if (instance != null)
        {
            phases = instance.currentPhase;
            episode = instance.currentEpisode;
        }
        else
        {
            Debug.LogWarning("phaseMngr is not assigned or does not contain a PhaseManager component.");
        }
    }

    void Update()
    {
        wLSituation = GameManager.situation;
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Lobby1");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [System.Obsolete]
    public void Continue()
    {
        SceneManager.UnloadScene("Rhythm Game");
    //    if (phases == "FreeTime" && episode == 1)
    //    {
    //        if (wLSituation)
    //        {
    //            SceneManager.LoadScene("Lobby1");
    //            dialogueTrigger.StartDialogue(" ", 31); // Call StartDialogue without arguments
    //        }
    //        else if (!wLSituation)
    //        {
    //            SceneManager.LoadScene("Lobby1");
    //            dialogueTrigger.StartDialogue(" ", 34); // Call StartDialogue without arguments
    //        }
    //    }
    //    else if (phases == "Special" && episode == 1)
    //    {
    //        if (AffectionSystem.Instance.affectionDictionary["Xina"] >= 3)
    //        {
    //            if (wLSituation)
    //            {
    //                SceneManager.LoadScene("Lobby1");
    //                dialogueTrigger.StartDialogue(" ", 400); // Call StartDialogue without arguments
    //            }
    //            else if (!wLSituation)
    //            {
    //                SceneManager.LoadScene("Lobby1");
    //                dialogueTrigger.StartDialogue(" ", 404); // Call StartDialogue without arguments
    //            }
    //        }
    //        else if (AffectionSystem.Instance.affectionDictionary["Xina"] >= 1)
    //        {
    //            if (wLSituation)
    //            {
    //                SceneManager.LoadScene("Lobby1");
    //                dialogueTrigger.StartDialogue(" ", 34); // Call StartDialogue without arguments
    //            }
    //            else if (!wLSituation)
    //            {
    //                SceneManager.LoadScene("Lobby1");
    //                dialogueTrigger.StartDialogue(" ", 37); // Call StartDialogue without arguments
    //            }
    //        }
            
    //    }
    }
}
