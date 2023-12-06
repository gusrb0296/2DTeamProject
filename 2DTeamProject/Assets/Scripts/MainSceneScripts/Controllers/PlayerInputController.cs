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

    [SerializeField] private float speed;
    private bool isSliding = false; // 슬라이딩 중인지 확인
    //public void OnJump(InputValue value)
    //{
    //    // Sliding
    //    if (Input.GetKeyDown(KeyCode.LeftControl))
    //    {
    //        StartCoroutine(Sliding());
    //    }
    //}
    //private IEnumerator Sliding()
    //{
    //    isSliding = true;
    //    _anim.SetBool("isSliding", true);

    //    // 슬라이딩 동작 구현
    //    Vector3 slidingDirection = transform.forward;
    //    float slidingTime = 0.5f; // 슬라이딩 하는 총 시간
    //    float startTime = Time.time;

    //    while (Time.time < startTime + slidingTime)
    //    {
    //        float elapsed = (Time.time - startTime) / slidingTime; // 슬라이딩 동작의 진행률
    //        float curve = elapsed * elapsed * (3 - 2 * elapsed); // Sigmoid-like curve for smooth start and end

    //        transform.position += slidingDirection * speed * curve * Time.deltaTime;
    //        yield return null;
    //    }

    //    isSliding = false;
    //    _anim.SetBool("isSliding", false);
    //}
}
