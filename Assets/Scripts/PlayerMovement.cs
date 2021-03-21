using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float maxVelocity = 6f;
    public float maxMovementForce = 6f;
    Rigidbody rb;
    public Vector3 movement;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if(rb.velocity.magnitude >= maxVelocity)
        {
            return;
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(maxMovementForce * transform.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(maxMovementForce * -transform.forward);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(maxMovementForce * transform.right);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(maxMovementForce * -transform.right);
        }
    }

    


}
