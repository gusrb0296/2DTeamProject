using UnityEngine;

public class BulletIncrease : ItemManager
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Bullet Count Up
            BulletCountUpItem();

            Destroy(gameObject);    // ���� ������Ʈ Ǯ��
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
