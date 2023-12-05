using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class BulletBounceItem : PlayerItemState
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Bounce
            BulletBounceItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
