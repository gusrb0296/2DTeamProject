using UnityEngine;

public class BulletPenetrate : PlayerItemState
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Pentrate
            BulletPenetrateItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
