using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RhythmGameButton : MonoBehaviour
{

    private static HashSet<ButtonController01> pressedButtons = new HashSet<ButtonController01>(); // Track pressed buttons

    private GameObject note; // Declare the 'note' variable here
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            note = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            note = null;
        }
    }
    // logic for checking note enter exit

    public bool Press(bool pressed)
    {
        // Initialize a variable to store the result.
        bool result = false;

        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    // Cast a ray from the touch position into the scene
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log($"Caller: {gameObject} hits {hit.collider.gameObject.name}");
                        // Check if the ray hit a button object
                        ButtonController01 button = hit.collider.gameObject.GetComponent < ButtonController01>();

                        result = true; // Set the result to true if a button was hit.
                    }
                }
            }
        }

        return result; // Return the result at the end of the method.
    }

    public bool Release(bool pressed)
    {
        // Initialize a variable to store the result.
        bool result = false;

        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            foreach (ButtonController01 button in pressedButtons)
            {
                result = false; // Set the result to false if any button is in the set.
                break; // Exit the loop early since we already found a button.
            }
            pressedButtons.Clear(); // Clear the set of pressed buttons
        }

        return result; // Return the result at the end of the method.
    }

}
