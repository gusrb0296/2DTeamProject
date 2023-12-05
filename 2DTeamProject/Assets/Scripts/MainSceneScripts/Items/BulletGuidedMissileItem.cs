using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuidedMissileItem : MonoBehaviour
{
    PlayerItemState _itemManager;

    private void Awake()
    {
        _itemManager = FindObjectOfType<PlayerItemState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // GuidedMissileItem Bounce
            _itemManager.BulletGuidedMissileItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
