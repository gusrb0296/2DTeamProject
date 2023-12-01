using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    #region ItemType
    protected enum ItemType
    {
        Normal,     
        BulletUPItem,       // bullet °¹¼ö Áõ°¡
        PenetrateItem,      // °üÅë
        BounceItem,         // Æ¨±è
        GuidedMissileItem   // À¯µµÅº
    }
    // ItemType Reset Value
    protected ItemType currentItem = ItemType.Normal;
    #endregion


    TopDownCharacterController _controller;

    Rigidbody2D bulletRigid;    // bullet Prefab Clone Rigidbody

    GameObject bullet; // ( bullet´Â player°¡ ¹ß»çÇÏ´Â ÃÑ¾Ë Prefab )

    //// Coroutine Caching
    //private IEnumerator ItemCoolTime;
    //private WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();

    // Basic Value
    [SerializeField] protected float force = 5;
    [SerializeField] protected float coolTime = 1.0f;
    [SerializeField] protected int bulltCount = 1;

    protected bool ItemCheck = true;

    private bool coolTimeCheck = true;


    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
    }

    private void Start()
    {
        _controller.OnAttackEvent += Attack;
    }

    private void Attack()
    {
        // CoolTime Check
        if (coolTimeCheck == true) StartCoroutine(CollTime(coolTime));
    }

    private void RecallBullet()
    {
        switch(currentItem)
        {
            case ItemType.Normal:
                GameObject playerBullet = Instantiate(bullet);
                playerBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
                ApplyAttck(playerBullet);
                break;
            case ItemType.BulletUPItem:
                GameObject playerBullet1 = Instantiate(bullet);
                GameObject playerBullet2 = Instantiate(bullet);
                playerBullet1.transform.position = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.4f, transform.position.z);
                playerBullet2.transform.position = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.4f, transform.position.z);
                ApplyAttck(playerBullet1);
                ApplyAttck(playerBullet2);
                break;
            case ItemType.PenetrateItem:
                break;
            case ItemType.BounceItem:
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
        bulletRigid.AddForce(transform.up * this.force, ForceMode2D.Impulse);
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

    protected IEnumerator ItemTime(float time, ItemType current)
    {
        // Item Active Disabled
        // ItemCheck = false;

        while (time > 0.0f)
        {
            if (current != this.currentItem) yield break;
            time -= Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }

        // Item Active Activate
        // ItemCheck = true;
    }
}
