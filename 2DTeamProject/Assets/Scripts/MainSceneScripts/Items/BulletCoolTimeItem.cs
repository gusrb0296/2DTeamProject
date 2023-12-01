using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

public class BulletCoolTimeItem : PlayerAttackSystem
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // Bullet CooTime Decrease
            coolTime -= 0.05f;
        }
    }
}
