using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIncrease : PlayerAttackSystem
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (ItemCheck == true && currentItem != ItemType.BulletUPItem)
            {
                currentItem = ItemType.BulletUPItem;
                StartCoroutine(ItemTime(5f, currentItem));
                currentItem = ItemType.Normal;
            }
        }
    }


}
