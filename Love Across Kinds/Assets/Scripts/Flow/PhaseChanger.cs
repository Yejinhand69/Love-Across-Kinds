using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhaseChanger : MonoBehaviour/*, IPointerDownHandler*/
{
    private static PhaseChanger instance;

    private string[] phases = { "PreProduction", "Filming", "FreeTime" };
  
    public string currentPhase;

    //Reference Character
    public GameObject preproductionCharacter;
    public GameObject filmingCharacter;
    public GameObject freeTimeCharacter;

    public int currentPhaseIndex = 0;

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
    }

    private void Start()
    {
        UpdatePhaseText();
    }

    public void Update()
    {
        Debug.Log(currentPhaseIndex);
    }

    private void UpdatePhaseText()
    {
        currentPhase = phases[currentPhaseIndex];
        Debug.Log("Current Phase: " + currentPhase);

        TransformCharacter();

        // You can update a UI text field or any other display with the currentPhase value.
    }
    public void ChangePhase()
    {
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Length;
        UpdatePhaseText();
    }

    public void TransformCharacter()
    {
        if (currentPhase == "PreProduction")
        {
            Debug.Log("Changing to preproduction phase");
            preproductionCharacter.SetActive(true);
            filmingCharacter.SetActive(false);
            freeTimeCharacter.SetActive(false);
        }
        else if (currentPhase == "Filming")
        {
            Debug.Log("Changing to filming phase");
            preproductionCharacter.SetActive(false);
            filmingCharacter.SetActive(true);
            freeTimeCharacter.SetActive(false);
        }
        else if (currentPhase == "FreeTime")
        {
            Debug.Log("Changing to free time phase");
            preproductionCharacter.SetActive(false);
            filmingCharacter.SetActive(false);
            freeTimeCharacter.SetActive(true);
        }
    }


}
