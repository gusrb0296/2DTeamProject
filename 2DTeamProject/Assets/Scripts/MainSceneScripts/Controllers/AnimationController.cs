using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    PlayerInputController _controller;

    private void Awake()
    {
        _controller = GetComponent<PlayerInputController>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += AnimState;
    }
    private void AnimState(Vector2 direction)
    {
        if (direction.x < 0)
        {
            //_anim.ResetTrigger("RunRight");
            _anim.SetTrigger("RunLeft");
        }
        else if (direction.x > 0)
        {
            //_anim.ResetTrigger("RunLeft");
            _anim.SetTrigger("RunRight");
        }
        else
        {
            _anim.SetTrigger("IdleUp");
        }
    }
}
