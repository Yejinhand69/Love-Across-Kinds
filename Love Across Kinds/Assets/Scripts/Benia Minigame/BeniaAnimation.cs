using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeniaAnimation : MonoBehaviour
{
    public Animator animator;
    

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void angry()
    {
        animator.SetInteger("option", 0);
    }
    public void sad()
    {
        animator.SetInteger("option", 1);
    }
    public void smile()
    {
        animator.SetInteger("option", 2);
    }
    public void idle()
    {
        animator.SetInteger("option", 3);
    }
}
