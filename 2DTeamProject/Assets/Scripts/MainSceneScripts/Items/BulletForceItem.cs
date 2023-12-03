using UnityEngine;

public class BulletForceItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Force Increase
            _player = collision.gameObject.GetComponent<PlayerAttackSystem>();
            BulletSpeedUp(_player);
            // 플레이어 사망시 초기화 필요.

            Destroy(gameObject);    // 추후 오브젝트 풀링 
        }
    }
}