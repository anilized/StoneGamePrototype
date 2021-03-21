using System;
using UnityEngine;

public interface IInput
{
    Action<Vector2> onMovementInput { get; set; }
    Action<Vector3> onMovementDirectionInput { get; set; }
}