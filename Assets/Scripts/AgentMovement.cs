using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    // Move player forward
    // Rotate player
    // Play the correct animation

    CharacterController controller;
    public float rotationSpeed, movementSpeed, gravitiy = 20.0f;
    Vector3 movementVector = Vector3.zero;
    private float desiredRotationAngle = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            if(movementVector.magnitude > 0)
            {
                RotateAgent();
            }
        }
        movementVector.y -= gravitiy;
        controller.Move(movementVector * Time.deltaTime);
    }

    public void HandleMovementDirection(Vector3 direction)
    {
        desiredRotationAngle = Vector3.Angle(transform.forward, direction); // always positive
        var crossProduct = Vector3.Cross(transform.forward, direction).y;
        if(crossProduct < 0)
        {
            desiredRotationAngle *= -1;
        }
    }

    private void RotateAgent()
    {
        if(desiredRotationAngle > 10 || desiredRotationAngle < -10)
        {
            transform.Rotate(Vector3.up * desiredRotationAngle * rotationSpeed * Time.deltaTime);
        }
    }

    public void HandleMovement(Vector2 input)
    {
        if (controller.isGrounded)
        {
            if(input.y > 0)
            {
                movementVector = transform.forward * movementSpeed;
            } else
            {
                movementVector = Vector3.zero;
            }
        }
    }
}
