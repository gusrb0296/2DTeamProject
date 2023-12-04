using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttackSystem : ItemManager
{
    #region Example
    //// Coroutine Caching
    //private IEnumerator ItemCoolTime;
    //private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    #endregion

    #region Global_Variale
    TopDownCharacterController _controller;

    Rigidbody2D bulletRigid;    // bullet Prefab Clone Rigidbody

    GameObject bullet; // ( bullet�� player�� �߻��ϴ� �Ѿ� Prefab )
    GameObject PenetrateItemBullet;
    GameObject bounceBullet;

    private bool coolTimeCheck = true;

    // ItemType Reset Value
    public ItemType currentItem;

    public float itemDuration = 0f;
    #endregion

    #region Initialization_Settings
    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        PenetrateItemBullet = Resources.Load<GameObject>("Prefabs/PenetrateItemBullet");
        bounceBullet = Resources.Load<GameObject>("Prefabs/BounceBullet");
    }

    private void Start()
    {
        _controller.OnAttackEvent += Attack;
    }
    #endregion

    #region Player_AttackLogic
    private void Update()
    {
        BulletStateCheck();
    }

    private void Attack()
    {
        // CoolTime Check
        if (coolTimeCheck == true) StartCoroutine(CollTime(coolTime));
    }

    private void RecallBullet()
    {
        switch (currentItem)
        {
            case ItemType.Normal:
                ItemNormalBullet();
                break;
            case ItemType.BulletUPItem:
                ItemBulletCountUp();
                break;
            case ItemType.PenetrateItem:
                ItemBulletPenetrateItem();
                break;
            case ItemType.BounceItem:
                ItemBulletBounce();
                break;
            case ItemType.GuidedMissileItem:
                break;
            default:
                break;
        }
    }

    private void ApplyAttck(GameObject obj)
    {
        bulletRigid = obj.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.up * force, ForceMode2D.Impulse);
    }

    private IEnumerator CollTime(float time)
    {
        // CoolTime Setting
        coolTimeCheck = false;

        RecallBullet();

        while (time > 0.0f)
        {
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        // CoolTime Reset
        coolTimeCheck = true;
    }
    #endregion

    #region BulletState
    private void ItemNormalBullet()
    {
        GameObject playerbullet = Instantiate(bullet);
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet);
    }

    private void ItemBulletCountUp()
    {
        GameObject playerBullet1 = Instantiate(bullet);
        GameObject playerBullet2 = Instantiate(bullet);
        playerBullet1.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, transform.position.z);
        playerBullet2.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerBullet1);
        ApplyAttck(playerBullet2);
    }

    private void ItemBulletPenetrateItem()
    {
        GameObject playerbullet = Instantiate(PenetrateItemBullet);
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet);
    }

    private void ItemBulletBounce()
    {
        GameObject playerbullet = Instantiate(bounceBullet);
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet);
    }
    #endregion

    private void BulletStateCheck()
    {
        if (currentItem != ItemType.Normal && itemDuration > 0f)
        {
            itemDuration -= Time.deltaTime;
        }
        if (itemDuration <= 0f && currentItem != ItemType.Normal)
        {
            itemDuration = 0f;
            currentItem = ItemType.Normal;
        }
    }
}

//public class PlayerItemBulletState : PlayerAttackSystem
//{
//    public void ItemNormalBullet()
//    {
//        GameObject playerBullet = Instantiate(bullet);
//        playerBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
//        ApplyAttck(playerBullet);
//    }
//}
