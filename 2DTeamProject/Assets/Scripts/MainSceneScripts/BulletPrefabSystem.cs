using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPrefabSystem : MonoBehaviour
{
    // Bullet�� Ball(��)�� �ε����� ����
    // ���� �ı� or �������� �ش�.
    // Bullet�� Destory or SetActive(false)

    // Bullet�� Wall(��) �� �ε����� Bullet�� Destory or SetActive(false) 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "Collider")
        {
            Destroy(gameObject);    // ���� ������ƮǮ��
        }
    }
}
