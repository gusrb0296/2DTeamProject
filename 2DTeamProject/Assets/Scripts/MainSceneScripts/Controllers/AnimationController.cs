using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    PlayerInputController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += AnimState;
    }
    private void Update()
    {
        //if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Left_Jump") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        ////GetCurrentAnimatorStateInfo(0).normalizedTime�� ���� �ִϸ��̼� Ŭ���� �󸶳� ����Ǿ������� ��Ÿ���� ���� ��ȯ
        //{
        //    _anim.ResetTrigger("JumpLeft");
        //}
        //if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Right_Jump") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        //{
        //    _anim.ResetTrigger("JumpRight");
        //}
        //if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Back_Jump") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        //{
        //    _anim.ResetTrigger("JumpBack");
        //}
    }
    private void AnimState(Vector2 direction)
    {
        if (direction.x > 0)
        {
            _anim.SetBool("RightRun", true);
            _anim.SetBool("LeftRun", false);
        }
        if (direction.x < 0)
        {
            _anim.SetBool("RightRun", false);
            _anim.SetBool("LeftRun", true);
        }
        if (direction.x == 0)
        {
            _anim.SetBool("RightRun", false);
            _anim.SetBool("LeftRun", false);
        }
    }
}
