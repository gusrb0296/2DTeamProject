using UnityEngine;

public class BulletCoolTimeItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet CooTime Decrease
            BulletDelayLower();
            // �÷��̾� ����� �ʱ�ȭ �ʿ�.

            Destroy(gameObject);    // ���� ������Ʈ Ǯ�� 
        }
    }
}
