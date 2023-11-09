using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController03 : MonoBehaviour
{
    public Material defaultMaterial;
    public Material pressedMaterial;
    public GameManager gameManager; // Reference to your GameManager
    //public bool canBePressed = false; // Boolean to indicate if a note can be pressed

    private static HashSet<ButtonController03> pressedButtons = new HashSet<ButtonController03>(); // Track pressed buttons

    private GameObject note03; // Declare the 'note' variable here

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note03"))
        {
            note03 = other.gameObject;
            //Debug.Log("true");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note03"))
        {
            note03 = null; // Clear the 'note' variable
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
                        ButtonController03 button = hit.collider.gameObject.GetComponent<ButtonController03>();

                        if (button != null)
                        {
                            // Change the material of the button that was touched
                            Renderer buttonRenderer = button.GetComponent<Renderer>();
                            buttonRenderer.material = button.pressedMaterial;
                            pressedButtons.Add(button); // Mark the button as pressed

                            Debug.Log("pressed");

                            if (note03 != null)
                            {
                                note03.SetActive(false);
                                note03 = null;
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
            foreach (ButtonController03 button in pressedButtons)
            {
                Renderer buttonRenderer = button.GetComponent<Renderer>();
                buttonRenderer.material = button.defaultMaterial;
            }
            pressedButtons.Clear(); // Clear the set of pressed buttons
        }
    }
}
