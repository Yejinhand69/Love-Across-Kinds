using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhaseChanger : MonoBehaviour
{
    //Reference Character
    public GameObject PreProductionCharacter;
    public GameObject FilmingCharacter;
    public GameObject FreeTimeCharacter;
    public GameObject SpecialCharacter;

    private void Start()
    {
        //UpdatePhaseText();
    }

    public void Update()
    {
        //Debug.Log(phaseManager.currentPhaseIndex);

        if (PreProductionCharacter != null && FilmingCharacter != null && FreeTimeCharacter != null && SpecialCharacter != null)//check if they exist in the current scene
        {

            if (PhaseManager.instance.currentPhase == "PreProduction")
            {
                PreProductionCharacter.SetActive(true);
                FilmingCharacter.SetActive(false);
                FreeTimeCharacter.SetActive(false);
                SpecialCharacter.SetActive(false);
            }
            else if (PhaseManager.instance.currentPhase == "Filming")
            {
                PreProductionCharacter.SetActive(false);
                FilmingCharacter.SetActive(true);
                FreeTimeCharacter.SetActive(false);
                SpecialCharacter.SetActive(false);
            }
            else if (PhaseManager.instance.currentPhase == "FreeTime")
            {
                PreProductionCharacter.SetActive(false);
                FilmingCharacter.SetActive(false);
                FreeTimeCharacter.SetActive(true);
                SpecialCharacter.SetActive(false);
            }
            else if(PhaseManager.instance.currentPhase == "Special")
            {
                PreProductionCharacter.SetActive(false);
                FilmingCharacter.SetActive(false);
                FreeTimeCharacter.SetActive(false);
                SpecialCharacter.SetActive(true);
            }
        }
    }
}
