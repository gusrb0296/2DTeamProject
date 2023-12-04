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
        if (value.Get<float>() > 0) // Ű�� ��������,
        {
            // �������� �޸��� �ִٸ� ���� ����
            // ���������� �޸��� �ִٸ� ������ ����
            // �� �� �ƴ϶�� ������
        }
        else // Ű�� ����������,
        {
            // �ƹ��͵� �ȳ����� �¿�� ���������� ������? �ִϸ��̼��� ���������� �۵��ȴٴ� �����Ͽ�
        }
    }
}
