using UnityEngine;

public class BulletPenetrate : MonoBehaviour
{
    PlayerItemState _itemManager;

    private void Awake()
    {
        _itemManager = FindObjectOfType<PlayerItemState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Pentrate
            _itemManager.BulletPenetrateItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
