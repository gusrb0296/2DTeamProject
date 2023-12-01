using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForceItem : PlayerAttackSystem
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Bullet Force Increase
            force += 0.5f;
        }
    }
}
