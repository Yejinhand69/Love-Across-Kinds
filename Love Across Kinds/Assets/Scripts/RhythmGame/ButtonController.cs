using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Material defaultMaterial;
    public Material pressedMaterial;

    private static HashSet<ButtonController> pressedButtons = new HashSet<ButtonController>(); // Track pressed buttons

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
                        // Check if the ray hit a button object
                        ButtonController button = hit.collider.gameObject.GetComponent<ButtonController>();
                        if (button != null)
                        {
                            // Change the material of the button that was touched
                            Renderer buttonRenderer = button.GetComponent<Renderer>();
                            buttonRenderer.material = button.pressedMaterial;
                            pressedButtons.Add(button); // Mark the button as pressed
                        }
                    }
                }
            }
        }

        // Restore the default material when all currently pressed buttons are released
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
        {
            foreach (ButtonController button in pressedButtons)
            {
                Renderer buttonRenderer = button.GetComponent<Renderer>();
                buttonRenderer.material = button.defaultMaterial;
            }
            pressedButtons.Clear(); // Clear the set of pressed buttons
        }
    }
}
