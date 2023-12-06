using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spritexplosion;
    private PlayerAttackSystem _playerAttackSystem;
    private bool coolTimeCheckValue;

    private void Awake()
    {
        _playerAttackSystem = GetComponent<PlayerAttackSystem>();
    }
    private void Update()
    {
        coolTimeCheckValue = _playerAttackSystem.CoolTimeCheck;
    }
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
            if (coolTimeCheckValue == true)
            {
                _anim.SetTrigger("Attack");
                StartCoroutine(ShowAndHide(_spritexplosion, 0.1f));
            }
        }
    }
    private IEnumerator ShowAndHide(SpriteRenderer sprite, float delay)
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
