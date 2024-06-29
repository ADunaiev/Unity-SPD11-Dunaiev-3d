using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2Script : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            animator.SetBool("isRotate", false);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetBool("isRotate", true);
        }
    }
}
