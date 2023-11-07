using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTransport : MonoBehaviour
{
    public GameObject transportPoint;

    // Update is called once per frame
    void Update()
    {
        if(PhaseManager.instance.currentPhase == "Filming")
        {
            transportPoint.SetActive(false);
        }
        else
        {
            transportPoint.SetActive(true);
        }
    }
}
