using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public float totalNotes;

    // Start is called before the first frame update
    void Start()
    {
        totalNotes = transform.childCount;
        Debug.Log("Child Count: " + transform.childCount);
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the screen is touched
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}