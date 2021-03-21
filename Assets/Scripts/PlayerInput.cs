using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInput : MonoBehaviour, IInput
{
    public Action<Vector2> onMovementInput { get; set; }
    public Action<Vector3> onMovementDirectionInput { get; set; }



    // Start is called before the first frame update
    void Start()
    {
        // Locks cursor on middle
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetMovementInput();
        GetMovementDirection();
    }

    private void GetMovementDirection()
    {
        var cameraForwardDirection = Camera.main.transform.forward;
        Debug.DrawRay(Camera.main.transform.position, cameraForwardDirection * 10, Color.red);
        var directionToMoveIn = Vector3.Scale(cameraForwardDirection, (Vector3.right + Vector3.forward));
        Debug.DrawRay(Camera.main.transform.position, directionToMoveIn * 10, Color.green);
        onMovementDirectionInput?.Invoke(directionToMoveIn);
    }

    private void GetMovementInput()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Is someone listening send input
        onMovementInput?.Invoke(input);
    }
}
