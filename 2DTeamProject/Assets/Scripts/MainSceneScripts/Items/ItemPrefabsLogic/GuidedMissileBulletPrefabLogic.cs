using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidedMissileBulletPrefabLogic : MonoBehaviour
{
    PlayerItemState _itemManager;

    List<GameObject> Balls;

    GameObject LockOnTarget;

    float nearDis;

    // LockOn Setting
    private void Awake()
    {
        _itemManager = FindObjectOfType<PlayerItemState>();
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
    }

    // LockOn Target Attack
    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, LockOnTarget.transform.position, _itemManager._player.Force * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "Wall" || collision.tag == "TopWall")
        {
            _itemManager.BulletCoolTimeReset();
            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
