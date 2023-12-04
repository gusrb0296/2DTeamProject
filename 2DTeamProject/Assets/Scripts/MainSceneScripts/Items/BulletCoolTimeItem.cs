using UnityEngine;

public class BulletCoolTimeItem : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet CooTime Decrease
            BulletDelayLower();
            // 플레이어 사망시 초기화 필요.

            Destroy(gameObject);    // 추후 오브젝트 풀링 
        }
    }
}
