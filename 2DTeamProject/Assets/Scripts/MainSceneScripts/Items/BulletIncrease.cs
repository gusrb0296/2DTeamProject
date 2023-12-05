using UnityEngine;

public class BulletIncrease : MonoBehaviour
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
            // Bullet Count Up
            _itemManager.BulletCountUpItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }

    //if (_player.currentItem != ItemType.BulletUPItem)
    //{
    //    _player.currentItem = ItemType.BulletUPItem;
    //    Debug.Log(_player.currentItem);
    //    StartCoroutine(ItemTime(5.0f, _player));
    //}

    //else //if (currentItem == ItemType.BulletUPItem)
    //{
    //    currentItem = ItemType.Normal;
    //    currentItem = ItemType.BulletUPItem;
    //    StartCoroutine(ItemTime(5f, currentItem));
    //    currentItem = ItemType.Normal;
    //}
}
