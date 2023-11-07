using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelUI : MonoBehaviour
{
    public GameManager gmMngr;
    public bool wLSituation;
    private DialogueTrigger dialogueTrigger; // Declare dialogueTrigger at the class level
    public GameObject dlgTrgr;

    void Start()
    {
        dialogueTrigger = dlgTrgr.GetComponent<DialogueTrigger>(); // Initialize dialogueTrigger
        wLSituation = gmMngr.situation;
    }
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Continue()
    {
        if (wLSituation)
        {
            SceneManager.LoadScene("MainMenu");
            dialogueTrigger.StartDialogue(); // Call StartDialogue without arguments
        }
        else if (!wLSituation)
        {
            SceneManager.LoadScene("MainMenu");
            dialogueTrigger.StartDialogue(); // Call StartDialogue without arguments
        }
    }
}
