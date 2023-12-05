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

            Destroy(gameObject);    // ���� ������Ʈ Ǯ��
        }
    }
}
