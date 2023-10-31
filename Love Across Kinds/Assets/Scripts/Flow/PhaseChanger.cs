using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhaseChanger : MonoBehaviour/*, IPointerDownHandler*/
{
    public static PhaseChanger instance;

    private string[] phases = { "PreProduction", "Filming", "FreeTime" };

    public string currentPhase;

    // Reference to the character transform
    //public Transform characterTransform;
    //private Vector3 preproductionPosition = new Vector3(-1.411109f, 0.6155657f, 0.5493989f);
    //private Vector3 filmingPosition = new Vector3(2.8f, 0.6155657f, 0.5493989f);
    //private Vector3 freeTimePosition = new Vector3(1.411109f, 0.6155657f, 3.11f);

    //private string PreProductionCharacterName = "PreproductionCharacter";
    //private string FilmingCharacterName = "FilmingCharacter";
    //private string FreeTimeCharacterName = "FreeTimeCharacter";

    //GameObject preproductionCharacter = GameObject.Find(name: "PreproductionCharacter");
    //GameObject filmingCharacter = GameObject.Find(name: "FilmingCharacter");
    //GameObject freeTimeCharacter = GameObject.Find(name: "FreeTimeCharacter");

    ////Reference Character
    public GameObject preproductionCharacter;
    public GameObject filmingCharacter;
    public GameObject freeTimeCharacter;

    public int currentPhaseIndex = 0;

    private void Awake()
    {
        UpdatePhaseText();//added
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
        //Debug.Log(currentPhaseIndex);
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
            //characterTransform.position = preproductionPosition;
            preproductionCharacter.SetActive(true);
            filmingCharacter.SetActive(false);
            freeTimeCharacter.SetActive(false);
        }
        else if (currentPhase == "Filming")
        {
            Debug.Log("Changing to filming phase");
            //characterTransform.position = filmingPosition;
            preproductionCharacter.SetActive(false);
            filmingCharacter.SetActive(true);
            freeTimeCharacter.SetActive(false);
        }
        else if (currentPhase == "FreeTime")
        {
            Debug.Log("Changing to free time phase");
            //characterTransform.position = freeTimePosition;
            preproductionCharacter.SetActive(false);
            filmingCharacter.SetActive(false);
            freeTimeCharacter.SetActive(true);
        }
    }


}
