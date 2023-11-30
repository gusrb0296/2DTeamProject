using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        
        CallMoveEvent(moveInput);
    }

    public void OnAttack(InputValue value)
        {
            if (value.isPressed)
            {
                CallAttackEvent();
            }
        }
}
