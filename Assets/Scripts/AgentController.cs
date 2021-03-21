using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{

    IInput input;
    AgentMovement movement;

    // Start is called before the first frame update
    private void OnEnable()
    {
        input = GetComponent<IInput>();
        movement = GetComponent<AgentMovement>();
        input.onMovementDirectionInput += movement.HandleMovementDirection;
        input.onMovementInput += movement.HandleMovement;
    }

    private void OnDisable()
    {
        input.onMovementDirectionInput -= movement.HandleMovementDirection;
        input.onMovementInput -= movement.HandleMovement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
