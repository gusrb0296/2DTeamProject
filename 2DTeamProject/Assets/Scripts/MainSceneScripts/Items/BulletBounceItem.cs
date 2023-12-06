using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletBounceItem : MonoBehaviour

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
            // Bullet Bounce
            _itemManager.BulletBounceItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
