using UnityEngine;

public class BulletPrefabSystem : MonoBehaviour
{
    PlayerItemState _itemManager;

    private void Awake()
    {
        _itemManager = FindObjectOfType<PlayerItemState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball" || collision.tag == "TopWall")
        {
            _itemManager.BulletCoolTimeReset();
            gameObject.SetActive(false);
        }
    }
}
