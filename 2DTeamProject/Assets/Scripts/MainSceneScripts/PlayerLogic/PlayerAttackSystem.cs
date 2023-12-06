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
    public ObjectManager _objectManager;

    // Component
    Rigidbody2D bulletRigid;    // bullet Prefab Clone Rigidbody

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
        _objectManager = FindObjectOfType<ObjectManager>();
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

    private void ApplyAttck(GameObject obj, float upforce)
    {
        bulletRigid = obj.GetComponent<Rigidbody2D>();
        bulletRigid.AddForce(transform.up * Force * upforce, ForceMode2D.Impulse);
    }
    #endregion

    #region BulletLogic
    private void ItemNormalBullet()
    {
        GameObject playerbullet = _objectManager.MakeObject("BulletNormal");
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet, 1);
    }

    private void ItemBulletCountUp()
    {
        GameObject playerBullet1 = _objectManager.MakeObject("BulletNormal");
        GameObject playerBullet2 = _objectManager.MakeObject("BulletNormal");
        playerBullet1.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, transform.position.z);
        playerBullet2.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerBullet1, 1.5f);
        ApplyAttck(playerBullet2, 1.5f);
    }

    private void ItemBulletPenetrateItem()
    {
        GameObject playerbullet = _objectManager.MakeObject("bulletPenetrate");
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet, 2f);
    }

    private void ItemBulletBounce()
    {
        GameObject playerbullet = _objectManager.MakeObject("BulletBounce");
        playerbullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        ApplyAttck(playerbullet, 1.2f);
    }

    private void ItemBulletGuidedMissile()
    {
        GameObject playerbullet = _objectManager.MakeObject("BulletGuided");
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
