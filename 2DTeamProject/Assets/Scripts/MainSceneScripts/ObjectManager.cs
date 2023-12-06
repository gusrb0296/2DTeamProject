using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{  
    GameObject bulletNormalPrefab;
    GameObject bulletBouncePrefab;
    GameObject bulletPenetratePrefab;
    GameObject bulletGuidedPrefab;
    GameObject ballFreezingPrefab;

    GameObject[] bulletBounce;
    GameObject[] bulletNormal;
    GameObject[] bulletPenetrate;
    GameObject[] bulletGuided;

    GameObject[] ballFreezing;

    GameObject[] targetPool;

    private void Awake()
    {
        bulletNormalPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        bulletBouncePrefab = Resources.Load<GameObject>("Prefabs/BounceBullet");
        bulletPenetratePrefab = Resources.Load<GameObject>("Prefabs/PenetrateItemBullet");
        bulletGuidedPrefab = Resources.Load<GameObject>("Prefabs/GuidedMissileBullet");
        ballFreezingPrefab = Resources.Load<GameObject>("Prefabs/BallFreezingLogic");

        bulletNormal = new GameObject[6];
        bulletBounce = new GameObject[10];
        bulletPenetrate = new GameObject[5];
        bulletGuided = new GameObject[5];
        ballFreezing = new GameObject[5];
    }

    private void Start()
    {
        Generate();
    }

    void Generate()
    {
        // Player Bullets
        for(int index = 0; index < bulletNormal.Length; index++)
        {
            bulletNormal[index] = Instantiate(bulletNormalPrefab);
            bulletNormal[index].SetActive(false);
        }

        for (int index = 0; index < bulletBounce.Length; index++)
        {
            bulletBounce[index] = Instantiate(bulletBouncePrefab);
            bulletBounce[index].SetActive(false);
        }

        for (int index = 0; index < bulletPenetrate.Length; index++)
        {
            bulletPenetrate[index] = Instantiate(bulletPenetratePrefab);
            bulletPenetrate[index].SetActive(false);
        }

        for (int index = 0; index < bulletGuided.Length; index++)
        {
            bulletGuided[index] = Instantiate(bulletGuidedPrefab);
            bulletGuided[index].SetActive(false);
        }

        // Use Item
        for (int index = 0; index < ballFreezing.Length; index++)
        {
            ballFreezing[index] = Instantiate(ballFreezingPrefab);
            ballFreezing[index].SetActive(false);
        }
    }

    public GameObject MakeObject(string type)
    {
        switch(type) 
        {
            case "BulletNormal":
                targetPool = bulletNormal;
                break;
            case "BulletBounce":
                targetPool = bulletBounce;
                break;
            case "BulletPenetrate":
                targetPool = bulletPenetrate;
                break;
            case "BulletGuided":
                targetPool = bulletGuided;
                break;
            case "BallFreezing":
                targetPool = ballFreezing;
                break;
        }
        // 비활성화된 오브젝트에 접근하여 활성화 시키고, 반환
        for (int index = 0; index < targetPool.Length; index++)
        {
            if (!targetPool[index].activeSelf)
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
