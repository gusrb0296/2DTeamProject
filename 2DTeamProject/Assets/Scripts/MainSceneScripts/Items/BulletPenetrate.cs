using UnityEngine;

public class BulletPenetrate : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Pentrate
            BulletPenetrateItem();

            Destroy(gameObject);    // ���� ������Ʈ Ǯ��
        }
    }
}
