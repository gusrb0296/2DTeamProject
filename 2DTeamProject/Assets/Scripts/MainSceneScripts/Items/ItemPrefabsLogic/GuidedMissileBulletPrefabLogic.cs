using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissileBulletPrefabLogic : PlayerItemState
{
    List<GameObject> Balls;

    GameObject LockOnTarget;

    float nearDis;

    // LockOn Setting
    private void Awake()
    {
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
        nearDis = Vector3.Distance(gameObject.transform.position, Balls[0].transform.position);
    }

    // LockOn Search
    private void Start()
    {
        // Null Value Ready
        LockOnTarget = Balls[0];

        // Search Near Distance Target
        foreach (GameObject index in Balls)
        {
            float distance = Vector3.Distance(gameObject.transform.position, index.transform.position);
            
            if (distance < nearDis)
            {
                LockOnTarget = index;
            }
        }
        Debug.Log(LockOnTarget);
    }

    // LockOn Target Attack
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, LockOnTarget.transform.position, Force * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball") || collision.collider.CompareTag("Wall") || collision.collider.CompareTag("TopWall"))
        {
            BulletCoolTimeReset();
            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
