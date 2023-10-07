using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    // Reference to the GameManager script
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        // Find the GameManager script in the scene and store a reference to it
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if the touch phase is "Began" (when the touch starts)
            if (touch.phase == TouchPhase.Began)
            {
                // Check if the note can be pressed
                if (canBePressed)
                {
                    gameObject.SetActive(false);
                    gameManager.NoteHit(); // Increase the score using the GameManager reference
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
