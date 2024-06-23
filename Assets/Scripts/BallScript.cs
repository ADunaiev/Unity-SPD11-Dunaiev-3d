using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    private float forceFactor = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float fx = Input.GetAxis("Horizontal") * Time.timeScale * forceFactor;
        float fz = Input.GetAxis("Vertical") * Time.timeScale * forceFactor;

        // rb.AddForce(fx, 0, fz); - за світовими координатами, незалежно від камери
        // якщо потрібно обертати камеру, то слід використовувати ії вектори forward та right
        Vector3 camForward = Camera.main.transform.forward;
        camForward.y = 0f;
        camForward = camForward.normalized;

        Vector3 moveDirection = 
            fz * camForward + 
            fx * Camera.main.transform.right;
        rb.AddForce(moveDirection);
    }
}
