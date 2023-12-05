using UnityEngine;

public class BulletPrefabSystem : ItemManager
{
    // Bullet�� Ball(��)�� �ε����� ����
    // ���� �ı� or �������� �ش�.
    // Bullet�� Destory or SetActive(false)

    // Bullet�� Wall(��) �� �ε����� Bullet�� Destory or SetActive(false) 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball") || collision.collider.CompareTag("TopWall"))
        {
            Destroy(gameObject);    // ���� ������ƮǮ��
        }
    }
}
