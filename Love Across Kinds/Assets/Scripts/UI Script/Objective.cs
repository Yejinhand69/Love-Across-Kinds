using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string[] task;
    public string[] title;

    public GameObject[] prologue;
    //public ObjectiveTitle T;

    private TextMeshProUGUI objectives;
    void Start()
    {
        objectives = GetComponent<TextMeshProUGUI>();

        
        //objectives.fontStyle = FontStyles.Bold;
    }

    void Update()
    {
        for (int i = 0; i < title.Length; i++)
        {                                    // title                                                 // task
            title[i] = "<size={4 + i * 5}><line-height=70%>" + "<b>" + title[i] + "</b>" + "</size><line-height=75%>";
        }

        if (PhaseManager.instance.currentPhase == "Prologue")
        {
            objectives.text = title[0] + "\n" + "\n" + task[0] + "\n" + task[1] + "\n" + task[2] + "\n" + "\n" + "\n" + "\n" + title[1] + "\n" + "\n" + task[3];            
        }

        if (PhaseManager.instance.currentPhase == "PreProduction")
        {
            objectives.text = title[3] + "\n" + task[5] + "\n" + task[6] + "\n" + task[7] + "\n" + "\n" + title[4] + "\n" + task[8] + "\n" + "\n" + title[5] + "\n" + task[9];

            for (int i = 0;i <= prologue.Length;i++)
            {
                prologue[i].SetActive(false);
            }
            
                  
        }

        if (PhaseManager.instance.currentPhase == "Filming")
        {
            objectives.text = title[7] + "\n" + task[11];
        }

        if (PhaseManager.instance.currentPhase == "FreeTime")
        {
            objectives.text = title[9] + "\n" + task[13];
        }

        if (PhaseManager.instance.currentPhase == "Special")
        {
            objectives.text = title[11] + "\n" + task[15];
        }

        //if (PhaseManager.instance.currentPhase == "Filming")
        //{

        //}

        //if (PhaseManager.instance.currentPhase == "Filming")
        //{

        //}

        //if (PhaseManager.instance.currentPhase == "Filming")
        //{

        //}
    }
}
