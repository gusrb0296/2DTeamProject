using UnityEngine;

public class BulletPrefabSystem : ItemManager
{
    // Bullet�� Ball(��)�� �ε����� ����
    // ���� �ı� or �������� �ش�.
    // Bullet�� Destory or SetActive(false)

    // Bullet�� Wall(��) �� �ε����� Bullet�� Destory or SetActive(false) 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _player = collision.GetComponent<PlayerAttackSystem>();

        // ��������� ���¸� ������ Destory
        if (_player.currentItem == ItemType.PenetrateItem)
        {
            if (collision.tag == "Collider") Destroy(gameObject);
        }
        
        else if (collision.tag == "Ball" || collision.tag == "Collider")
        {
            Destroy(gameObject);    // ���� ������ƮǮ��
        }
    }
}
