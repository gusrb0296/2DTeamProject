using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopdownMovement : MonoBehaviour
{
    private TopDownCharacterController _controller;
    private Rigidbody2D _rigidbody;
    private Vector2 _movementDirection = Vector2.zero;
    private float x;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        _controller.OnMoveEvent += Move; // 구독
    }
    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }
    private void ApplyMovent(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }
    private void FixedUpdate()
    {
        ApplyMovent(_movementDirection);
        CollisionWithWall();
    }
    private void CollisionWithWall()
    {
        x = transform.position.x;
        if (x < -8.3f)
        {
            x = -8.3f;
        }
        if (x > 8.3f)
        {
            x = 8.3f;
        }
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
