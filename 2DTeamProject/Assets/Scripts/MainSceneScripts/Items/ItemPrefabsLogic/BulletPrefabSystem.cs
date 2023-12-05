using UnityEngine;

public class BulletPrefabSystem : PlayerItemState
{
    // Bullet이 Ball(공)에 부딪힐때 로직
    // 공은 파괴 or 데미지를 준다.
    // Bullet은 Destory or SetActive(false)

    // Bullet이 Wall(벽) 에 부딪히면 Bullet은 Destory or SetActive(false) 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ball") || collision.collider.CompareTag("TopWall"))
        {
            BulletCoolTimeReset();
            Destroy(gameObject);    // 추후 오브젝트풀링
        }
    }
}
