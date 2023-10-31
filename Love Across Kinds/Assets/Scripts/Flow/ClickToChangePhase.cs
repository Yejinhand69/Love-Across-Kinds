using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToChangePhase : MonoBehaviour
{
    
    private PhaseChanger phaseChanger; // Reference to your PhaseChanger script

    private void Start()
    {
        // Find and store a reference to the PhaseChanger script attached to another GameObject.
        phaseChanger = FindObjectOfType<PhaseChanger>();
    }

    private void Update()
    {
        // Check for mouse click or touch input
        if (Input.GetMouseButtonDown(0) && phaseChanger != null)
        {
            // Cast a ray from the screen point where you clicked/touched
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object you clicked/touched has the "phase changer" tag
                if (hit.collider.CompareTag("phase changer"))
                {
                    // Call the ChangePhase() function in the PhaseChanger script
                    phaseChanger.ChangePhase();
                }
            }
        }
    }
}
