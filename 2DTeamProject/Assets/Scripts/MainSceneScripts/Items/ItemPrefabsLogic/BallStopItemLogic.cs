using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallStopItemLogic : MonoBehaviour
{
    List<GameObject> Balls;
    List<GameObject> BallsCheck;

    float times = 5;

    private void Awake()
    {
        FirstCheck();
    }

    private void Start()
    {
        BallStop();
        SoundManager.instance.PlaySFX("StopBallItem");
    }

    private void Update()
    {
        BallCountCheck();

        // Time Decrease
        Timer();

        // If Broken the Ball, Check again
        if (BallsCheck.Count != Balls.Count && times > 0)
        {
            BallCountCheck();
            BallStop();
        }

        // Time is zero ? Balls Activity again
        if (times <= 0)
        {
            BallStart();

            Destroy(gameObject);
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