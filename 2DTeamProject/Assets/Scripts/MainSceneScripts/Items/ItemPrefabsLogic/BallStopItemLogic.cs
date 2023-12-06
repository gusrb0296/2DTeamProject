using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStopItemLogic : MonoBehaviour
{
    Rigidbody2D _rigid;

    List<GameObject> Balls;
    List<GameObject> BallsCheck;

    SpriteRenderer spriteRenderer;

    float times = 5;

    bool ItemCheck = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _rigid.AddForce(transform.up * -2, ForceMode2D.Impulse);
    }

    private void Update()
    {
        BallCountCheck();
        if (ItemCheck == true)
        {
            Timer();
            if (BallsCheck.Count != Balls.Count && times > 0)
            {
                BallCountCheck();
                BallStop();
            }
        }
        if (times <= 0)
        {
            BallStart();

            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(ItemCheck == false)
            {
                ItemCheck = true;
                FirstCheck();
                BallStop();

                spriteRenderer.color = new Color(1, 1, 1, 0);
            }
            //Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }

    #region Logic
    void Timer()
    {
        times -= Time.deltaTime;
    }

    void FirstCheck()
    {
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
        BallsCheck = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
    }

    void BallCountCheck()
    {
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
    }

    void BallStop()
    {
        foreach (GameObject index in Balls)
        {
            Rigidbody2D rigid = index.GetComponent<Rigidbody2D>();
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
    }

    void BallStart()
    {
        int num = 1;
        foreach (GameObject index in Balls)
        {
            Rigidbody2D rigid = index.GetComponent<Rigidbody2D>();
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (num == 1)
            {
                rigid.AddForce(Vector2.left * 200);
                num = 2;
            }
            else
            {
                rigid.AddForce(Vector2.right * 200);
                num = 1;
            }
        }
    }
    #endregion
}
