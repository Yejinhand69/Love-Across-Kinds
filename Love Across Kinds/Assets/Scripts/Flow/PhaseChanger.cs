using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhaseChanger : MonoBehaviour
{
    private string[] phases = { "Prologue","PreProduction", "Filming", "FreeTime" };//added prologue phase

    //Reference Character
    public GameObject PreProductionCharacter;
    public GameObject FilmingCharacter;
    public GameObject FreeTimeCharacter;

    private void Start()
    {
        UpdatePhaseText();
    }

    public void Update()
    {
        //Debug.Log(phaseManager.currentPhaseIndex);

        if (PreProductionCharacter != null && FilmingCharacter != null && FreeTimeCharacter != null)//check if they exist in the current scene
        {

            if (PhaseManager.instance.currentPhaseIndex == 0)
            {
                PreProductionCharacter.SetActive(true);
                FilmingCharacter.SetActive(false);
                FreeTimeCharacter.SetActive(false);
            }
            else if (PhaseManager.instance.currentPhaseIndex == 1)
            {
                PreProductionCharacter.SetActive(false);
                FilmingCharacter.SetActive(true);
                FreeTimeCharacter.SetActive(false);
            }
            else if (PhaseManager.instance.currentPhaseIndex == 2)
            {
                PreProductionCharacter.SetActive(false);
                FilmingCharacter.SetActive(false);
                FreeTimeCharacter.SetActive(true);
            }
        }
    }

    private void UpdatePhaseText()
    {
        PhaseManager.instance.currentPhase = phases[PhaseManager.instance.currentPhaseIndex];
        Debug.Log("Current Phase: " + PhaseManager.instance.currentPhase);

        // Save the currentPhaseIndex to PlayerPrefs
        //PlayerPrefs.SetInt("CurrentPhaseIndex", currentPhaseIndex);
        //PlayerPrefs.Save();

        // You can update a UI text field or any other display with the currentPhase value.
    }
    public void ChangePhase()
    {
        PhaseManager.instance.currentPhaseIndex = (PhaseManager.instance.currentPhaseIndex + 1) % phases.Length;
        UpdatePhaseText();
    }

}
