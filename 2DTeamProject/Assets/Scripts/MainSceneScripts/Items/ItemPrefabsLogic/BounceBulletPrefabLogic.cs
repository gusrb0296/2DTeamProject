using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceBulletPrefabLogic : MonoBehaviour
{
    PlayerItemState _itemManager;

    const float _Radian = 180f;
    bool firstWallCheck = true;
    Rigidbody2D _rigid;

    private int[] arrAngles = { 105, 135, 165, 195, 225, 255 }; // 225 : Right Bounce, 135 : Left

    private int bulletLifeCount = 0;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _itemManager = FindObjectOfType<PlayerItemState>();
    }

    private void OnEnable()
    {
        bulletLifeCount = 0;
        firstWallCheck = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            if (firstWallCheck == true)
            {
                // byllet CoolTime Reset
                _itemManager.BulletCoolTimeReset();
                // Random Angle Setting
                int randomAngle = Random.Range(0, arrAngles.Length);
                Vector3 tmps = transform.eulerAngles;
                tmps.z = arrAngles[randomAngle];
                transform.eulerAngles = tmps;
                firstWallCheck = false;
            }
            else
            {
                // Bounce Angle Setting
                Vector3 tmp = transform.eulerAngles;
                tmp.z = _Radian - tmp.z;
                transform.eulerAngles = tmp;
                // Bounce After AddForce
            }
            //_rigid.velocity = Vector3.zero;
            _rigid.AddForce(transform.up * _itemManager._player.Force * 1.2f, ForceMode2D.Impulse);
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (_Radian * 2) - tmp.z;
            transform.eulerAngles = tmp;
            //_rigid.velocity = Vector3.zero;
            _rigid.AddForce(transform.up * _itemManager._player.Force * 1.2f, ForceMode2D.Impulse);
        }
        bulletLifeCount++;

        if (collision.collider.CompareTag("Ball"))
        {
            if(firstWallCheck == true) _itemManager.BulletCoolTimeReset();
            firstWallCheck = false;
            gameObject.SetActive(false);
        }

        // bullet Destory Condition ( 오브젝트 풀링 필요 )
        if(bulletLifeCount >= 4)
        {
            _itemManager.BulletCoolTimeReset();
            firstWallCheck = false;
            gameObject.SetActive(false);
        }
    }
}
