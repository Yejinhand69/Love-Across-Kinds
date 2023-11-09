using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController02 : MonoBehaviour
{
    public Material defaultMaterial;
    public Material pressedMaterial;
    public GameManager gameManager; // Reference to your GameManager
    //public bool canBePressed = false; // Boolean to indicate if a note can be pressed

    private static HashSet<ButtonController02> pressedButtons = new HashSet<ButtonController02>(); // Track pressed buttons

    private GameObject note02; // Declare the 'note' variable here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note02"))
        {
            note02 = other.gameObject;
            //Debug.Log("true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note02"))
        {
            note02 = null; // Clear the 'note' variable
            //Debug.Log("false");
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                        ButtonController02 button = hit.collider.gameObject.GetComponent<ButtonController02>();

                        if (button != null)
                        {
                            // Change the material of the button that was touched
                            Renderer buttonRenderer = button.GetComponent<Renderer>();
                            buttonRenderer.material = button.pressedMaterial;
                            pressedButtons.Add(button); // Mark the button as pressed

                            Debug.Log("pressed");

                            if (note02 != null)
                            {
                                note02.SetActive(false);
                                note02 = null;
                                // Call GameManager's NoteHit function
                                button.gameManager.NoteHit();
                            }
                            Debug.Log("true");


                        }
                    }
                }
            }
        }

        // Restore the default material when all currently pressed buttons are released
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            foreach (ButtonController02 button in pressedButtons)
            {
                Renderer buttonRenderer = button.GetComponent<Renderer>();
                buttonRenderer.material = button.defaultMaterial;
            }
            pressedButtons.Clear(); // Clear the set of pressed buttons
        }
    }
}
