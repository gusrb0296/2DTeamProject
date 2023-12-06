using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : TopDownCharacterController
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _explosionSprite;
    [SerializeField] private SpriteRenderer _playerSprite;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float _dashDuration = 0.2f;  // 대시와 이펙트의 지속 시간은 동일하므로 같은 변수 사용
    [SerializeField] private float _dashFadeSpeed = 5f;  // 대시 이펙트의 투명도 감소 속도
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
                StartCoroutine(ShowAndHide(_explosionSprite, 0.1f));
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
        {
            StartCoroutine(Dash(_dashDuration));
        }
    }
    private IEnumerator Dash(float dashTime) // 대쉬 기능
    {
        Vector3 dashDirection = playerMoveDir.x > 0 ? Vector3.right : Vector3.left;
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            transform.position += dashDirection * speed * Time.deltaTime; // 대쉬 속도를 고정하고 방향에 따라 이동
            StartCoroutine(DashEffect(_playerSprite, _dashDuration, _dashFadeSpeed));  // 대시 이펙트 생성
            yield return null;
        }
    }
    private IEnumerator DashEffect(SpriteRenderer sprite, float dashEffectTime, float dashEffectfadeSpeed)
    {
        // 스프라이트 복사본 생성
        GameObject ghost = new GameObject();
        SpriteRenderer ghostSprite = ghost.AddComponent<SpriteRenderer>();
        ghostSprite.sprite = sprite.sprite;
        ghost.transform.position = transform.position;
        ghost.transform.rotation = transform.rotation;
        ghost.transform.localScale = transform.localScale;

        // 일정 시간 동안 복사본을 보이게 한 후 투명도를 점차 감소시킴
        float startTime = Time.time;
        while (Time.time < startTime + dashEffectTime)
        {
            float alpha = Mathf.Lerp(1f, 0f, (Time.time - startTime) * dashEffectfadeSpeed); // 투명도 감소
            ghostSprite.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
        // 복사본 제거
        Destroy(ghost);
    }
}
