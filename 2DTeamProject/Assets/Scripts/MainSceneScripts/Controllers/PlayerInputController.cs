using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spritexplosion;
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
        if (value.Get<float>() > 0) // 키가 눌렸을때,
        {
            // 왼쪽으로 달리고 있다면 왼쪽 점프
            // 오른쪽으로 달리고 있다면 오른쪽 점프
            // 둘 다 아니라면 백점프
        }
        else // 키가 떼어졌을때,
        {
            // 아무것도 안넣으면 좌우로 움직여지지 않을까? 애니메이션이 정상적으로 작동된다는 가정하에
        }
    }
}
