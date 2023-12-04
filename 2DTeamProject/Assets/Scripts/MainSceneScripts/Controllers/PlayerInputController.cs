using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    private Vector2 moveInput;
    public void Update()
    {
        CallMoveEvent(moveInput);
    }
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnAttack(InputValue value)
        {
            if (value.isPressed)
            {
                CallAttackEvent();
            }
        }

    public void OnJump()
    {
        //
    }
}
