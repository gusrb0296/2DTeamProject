using UnityEngine;

public class BulletForceItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Force Increase
            BulletSpeedUp();
            // �÷��̾� ����� �ʱ�ȭ �ʿ�.

            Destroy(gameObject);    // ���� ������Ʈ Ǯ�� 
        }
    }
}