using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    #region Example
    //// Coroutine Caching
    //private IEnumerator ItemCoolTime;
    //private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    #endregion

    #region Global_Variale
    // Scripts
    TopDownCharacterController _controller;
    PlayerItemState _itemManager;

    // Component
    Rigidbody2D bulletRigid;    // bullet Prefab Clone Rigidbody

    // Bullet Prefab
    GameObject bullet; // ( bullet는 player가 발사하는 총알 Prefab )
    GameObject PenetrateItemBullet;
    GameObject bounceBullet;
    GameObject guidedMissileBullet;

    // Basic Value
    public float Force { get; set; }
    public bool CoolTimeCheck {  get; set; }
    #endregion

    #region Initialization_Settings
    private void Awake()
    {
        // Scripts Search
        _controller = GetComponent<TopDownCharacterController>();
        _itemManager = FindObjectOfType<PlayerItemState>();
        // Resources Load
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        PenetrateItemBullet = Resources.Load<GameObject>("Prefabs/PenetrateItemBullet");
        bounceBullet = Resources.Load<GameObject>("Prefabs/BounceBullet");
        guidedMissileBullet = Resources.Load<GameObject>("Prefabs/GuidedMissileBullet");
    }

    private void Start()
    {
        _controller.OnAttackEvent += Attack;
        PlayerBasicValue();
    }
    #endregion

    #region Player_AttackLogic
    private void Attack()
    {
        // CoolTime Check
        if (CoolTimeCheck == true)
        {
            SoundManager.instance.PlaySFX("Attack");
            CoolTimeCheck = false;
            RecallBullet();
        }
    }

    private void RecallBullet()
    {
        switch (_itemManager.currentItem)
        {
            case PlayerItemState.ItemType.Normal:
                ItemNormalBullet();
                break;
            case PlayerItemState.ItemType.BulletUPItem:
                ItemBulletCountUp();
                break;
            case PlayerItemState.ItemType.PenetrateItem:
                ItemBulletPenetrateItem();
                break;
            case PlayerItemState.ItemType.BounceItem:
                ItemBulletBounce();
                break;
            case PlayerItemState.ItemType.GuidedMissileItem:
                ItemBulletGuidedMissile();
                break;
            default:
                break;
        }
    }

    private void ApplyAttck(GameObject obj)
    {
        bulletRigid = obj.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.up * Force, ForceMode2D.Impulse);
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

    private void ItemBulletGuidedMissile()
    {
        GameObject playerbullet = Instantiate(guidedMissileBullet);
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
    }
    #endregion

    #region StateReset

    private void PlayerBasicValue()
    {
        _itemManager.currentItem = PlayerItemState.ItemType.Normal;
        Force = 8f;
        CoolTimeCheck = true;
    }
    #endregion
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
