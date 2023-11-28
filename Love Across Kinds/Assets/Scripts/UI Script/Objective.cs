using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Objective : MonoBehaviour
{
    public string[] task;
    public string[] title;

    public GameObject[] prologue;
    public GameObject[] Preproduction;
    public GameObject filming;
    public GameObject[] freeTime;
    public GameObject[] interlude;
    //public ObjectiveTitle T;

    private TextMeshProUGUI objectives;
    void Start()
    {
        objectives = GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < title.Length; i++)
        {                                    // title                                                 // task
            title[i] = "<size={4 + i * 5}><line-height=70%>" + "<b>" + title[i] + "</b>" + "</size><line-height=75%>";
        }

        //objectives.fontStyle = FontStyles.Bold;
    }

    void Update()
    {
        

        if (PhaseManager.instance.currentPhase == "Prologue")
        {
            objectives.text = title[0] + "\n" + "\n" + task[0] + "\n" + task[1] + "\n" + task[2] + "\n" + "\n" + "\n" + "\n" + "\n" + title[1] + "\n" + "\n" + task[3];            
        }

        if (PhaseManager.instance.currentPhase == "PreProduction")
        {
            objectives.text = title[3] + "\n" + "\n" + task[5] + "\n" + task[6] + "\n" + task[7] + "\n" + "\n" + "\n" + "\n" + title[4] + "\n" + "\n" + task[8] + "\n" + "\n" + "\n" + "\n" + title[5] + "\n" + "\n" + task[9];

            for (int i = 0; i <= Preproduction.Length; i++)
            {
                Preproduction[i].SetActive(true);
                prologue[i].SetActive(false);
            }
        }

        if (PhaseManager.instance.currentPhase == "Filming")
        {
            objectives.text = title[7] + "\n" + "\n" + task[11] + "\n" + "\n" + task[12];

            filming.SetActive(true);
            for (int i = 0; i <= 10; i++)
            {               
                Preproduction[i].SetActive(false);    
            }
            
        }

        if (PhaseManager.instance.currentPhase == "FreeTime")
        {
            objectives.text = title[9] + "\n"+ "\n" + task[14] + "\n" + "\n" + task[15];

            filming.SetActive(false);
            for (int i = 0; i <= freeTime.Length; i++)
            {     
                freeTime[i].SetActive(true);
            }
            
        }

        if (PhaseManager.instance.currentPhase == "Special")
        {
            objectives.text = title[11] + "\n" + "\n" + task[17] + "\n" + "\n" + task[18];

            for (int i = 0; i <= freeTime.Length; i++)
            {
                freeTime[i].SetActive(false);
                interlude[i].SetActive(true);
            }     
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
