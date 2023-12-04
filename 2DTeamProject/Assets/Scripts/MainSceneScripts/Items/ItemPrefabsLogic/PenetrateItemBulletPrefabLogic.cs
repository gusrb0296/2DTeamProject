using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateItemBulletPrefabLogic : ItemManager
{
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("TopWall"))
    //    {
    //        Destroy(gameObject);    // 추후 오브젝트풀링
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "TopWall")
        {
            Destroy(gameObject);    // 추후 오브젝트풀링
        }
    }
}
