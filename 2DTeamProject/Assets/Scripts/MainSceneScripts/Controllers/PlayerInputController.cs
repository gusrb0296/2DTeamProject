using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spritexplosion;

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
            _anim.SetTrigger("Attack");
            StartCoroutine(ShowAndHide(_spritexplosion, 0.1f));
        }
    }
    IEnumerator ShowAndHide(SpriteRenderer sprite, float delay)
    {
        sprite.enabled = true;
        yield return new WaitForSeconds(delay);
        sprite.enabled = false;
    }

    public void OnJump(InputValue value)
    {
        //
    }
}
