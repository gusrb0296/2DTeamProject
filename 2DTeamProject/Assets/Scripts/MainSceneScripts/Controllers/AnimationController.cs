using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
        _controller.OnMoveEvent += AnimRun;
    }
    public void AnimRun(Vector2 direction)
    {
        _anim.SetFloat("IsRun", direction.magnitude);
        transform.rotation = new Quaternion(0, direction.x > 0 ? 180 : 0, 0, 0);
    }
}
