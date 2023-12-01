using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBall : MonoBehaviour
{
    private int _ballHp;
    [SerializeField] private float speed;
    private Rigidbody2D _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Launch();
        BallSpawn();
    }
    private void Launch()
    {
        // 왼쪽, 오른쪽 랜덤한 값을 받아 해당 방향으로 Speed만큼 곱한 속도로 이동
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        Vector2 dir = new Vector2(x, 0);
        _rigidbody.AddForce(dir * speed);
    }

    public void BallSpawn()
    {
        // x: -8 ~ 8 /  y: 2 ~ 3 사이로 스폰
        Vector2 RandomPos = new Vector2(Random.Range(-8, 8), Random.Range(2, 3));
        this.transform.position = RandomPos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("맞았습니다.");
        }
    }
    private void Split()
    {
        // 구현 예정
    }
}
