using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhaseChanger : MonoBehaviour, IPointerDownHandler
{
    public string[] phases = { "preproduction", "filming", "free time" };
    private int currentPhaseIndex = 0;
    public string currentPhase;

    // Reference to the camera transform
    public Transform cameraTransform;
    private Vector3 preproductionPosition = new Vector3(0f, 1f, -7.06f);
    private Vector3 filmingPosition = new Vector3(0f, 4.589f, -7.06f);
    private Vector3 freeTimePosition = new Vector3(0f, 8.523f, -7.06f);

    private void Start()
    {
        UpdatePhaseText();
    }

    public void Update()
    {
       
    }

    private void UpdatePhaseText()
    {
        currentPhase = phases[currentPhaseIndex];
        Debug.Log("Current Phase: " + currentPhase);

       
        //TransformCamera();


        // You can update a UI text field or any other display with the currentPhase value.
    }

    private void TransformCamera()
    {
        //camera
        if (currentPhase == "preproduction")
        {
            Debug.Log("Changing to preproduction phase");
            cameraTransform.position = preproductionPosition;
        }
        else if (currentPhase == "filming")
        {
            Debug.Log("Changing to filming phase");
            cameraTransform.position = filmingPosition;
        }
        else if (currentPhase == "free time")
        {
            Debug.Log("Changing to free time phase");
            cameraTransform.position = freeTimePosition;
        }
    }



    public void ChangePhase()
    {
        currentPhaseIndex = (currentPhaseIndex + 1) % phases.Length;
        UpdatePhaseText();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(tag == "phase changer")
        {
            ChangePhase();
        }
    }
}
