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
    public Animator animator;

    private void Start()
    {
        UpdatePhaseText();
    }

    private void Update()
    {
        // Reset all phase boolean parameters to false
        animator.SetBool("IsPreproduction", false);
        animator.SetBool("IsFilming", false);
        animator.SetBool("IsFreeTime", false);

        if (currentPhase == "preproduction")
        {
            animator.SetBool("IsPreproduction", true);
        }
        else if (currentPhase == "filming")
        {
            animator.SetBool("IsFilming", true);
        }
        else if (currentPhase == "free time")
        {
            animator.SetBool("IsFreeTime", true);
        }

    }

    private void UpdatePhaseText()
    {
        currentPhase = phases[currentPhaseIndex];
        Debug.Log("Current Phase: " + currentPhase);

        // You can update a UI text field or any other display with the currentPhase value.
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
