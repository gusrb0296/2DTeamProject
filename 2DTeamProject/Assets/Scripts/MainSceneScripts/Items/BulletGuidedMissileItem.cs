using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuidedMissileItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // GuidedMissileItem Bounce
            BulletGuidedMissileItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
