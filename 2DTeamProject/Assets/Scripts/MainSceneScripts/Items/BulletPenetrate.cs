using UnityEngine;

public class BulletPenetrate : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Pentrate
            _player = collision.gameObject.GetComponent<PlayerAttackSystem>();
            BulletPenetrateItem(_player);

            Destroy(gameObject);    // ���� ������Ʈ Ǯ��
        }
    }
}
