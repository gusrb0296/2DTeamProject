using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateItemBulletPrefabLogic : MonoBehaviour
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("TopWall"))
    //    {
    //        Destroy(gameObject);    // 추후 오브젝트풀링
    //    }
    //}

    PlayerItemState _itemManager;

    private void Awake()
    {
        _itemManager = FindObjectOfType<PlayerItemState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TopWall")
        {
            _itemManager.BulletCoolTimeReset();
            gameObject.SetActive(false);
        }
    }
}
