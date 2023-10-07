using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;

    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the screen is touched
        if (!hasStarted)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                hasStarted = true;
            }
        }
        else
        {
            // Move the object downward
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}