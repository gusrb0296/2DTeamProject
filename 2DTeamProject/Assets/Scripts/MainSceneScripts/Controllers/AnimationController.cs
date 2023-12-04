using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _sprite;
    PlayerInputController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += AnimRun;
    }
    private void Update()
    {
        
        //if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Left_Jump") && _anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        ////GetCurrentAnimatorStateInfo(0).normalizedTime은 현재 애니메이션 클립이 얼마나 재생되었는지를 나타내는 값을 반환
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
    private void AnimRun(Vector2 direction)
    {
        _anim.SetFloat("IsRun", direction.magnitude);
        transform.rotation = new Quaternion(0, direction.x > 0 ? 180 : 0, 0, 0);
    }
}
