using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

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
        LookOnCheck();
    }

    // LockOn Search
    private void Start()
    {
        LookOnSearch();
    }

    // LockOn Target Attack
    private void FixedUpdate()
    {
        LookOnTargetAttack();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "Wall" || collision.tag == "TopWall")
        {
            _itemManager.BulletCoolTimeReset();
            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }

    #region Logic

    private void LookOnCheck()
    {
        Balls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Ball"));
        if ( Balls != null ) nearDis = Vector3.Distance(gameObject.transform.position, Balls[0].transform.position);
    }

    private void LookOnSearch()
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

    private void LookOnTargetAttack()
    {
        // LookOnTarget Null Check
        if (LockOnTarget != null)
            transform.position = Vector3.MoveTowards(transform.position, LockOnTarget.transform.position, _itemManager._player.Force * Time.deltaTime);
        else
        {
            // LookOnTarget == null ? ReSearch
            LookOnCheck();
            LookOnSearch();
        }
    }
    #endregion
}
