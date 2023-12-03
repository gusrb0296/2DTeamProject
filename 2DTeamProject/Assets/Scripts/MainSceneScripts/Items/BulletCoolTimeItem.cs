using UnityEngine;

public class BulletCoolTimeItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet CooTime Decrease
            _player = collision.gameObject.GetComponent<PlayerAttackSystem>();
            BulletDelayLower(_player);
            // �÷��̾� ����� �ʱ�ȭ �ʿ�.

            Destroy(gameObject);    // ���� ������Ʈ Ǯ�� 
        }
    }
}
