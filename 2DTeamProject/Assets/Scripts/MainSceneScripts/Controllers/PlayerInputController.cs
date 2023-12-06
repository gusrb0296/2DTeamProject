using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spritexplosion;
    [SerializeField] private float speed;
    private Vector2 playerMoveDir;
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
        playerMoveDir = moveInput;
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
    
    public void OnDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            StartCoroutine(Dash(0.2f));
    }
    private IEnumerator Dash(float dashTime)
    {
        Vector3 dashDirection = playerMoveDir.x > 0 ? Vector3.right : Vector3.left;
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.position += dashDirection * speed * Time.deltaTime; // 대쉬 속도를 고정하고 방향에 따라 이동
            yield return null;
        }
    }
}
