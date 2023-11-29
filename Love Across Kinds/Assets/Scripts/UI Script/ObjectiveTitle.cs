using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ObjectiveTitle : MonoBehaviour
{
    public string[] title;
    public TextMeshProUGUI T;
    void Start()
    {
        T = GetComponent<TextMeshProUGUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        T.fontStyle = FontStyles.Bold;
    }
}
