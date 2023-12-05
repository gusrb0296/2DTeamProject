using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    #region ItemTypeEnum
    public enum ItemType
    {
        Normal,
        BulletUPItem,       // bullet ���� ����
        PenetrateItem,      // ����
        BounceItem,         // ƨ��
        GuidedMissileItem   // ����ź
    }
    #endregion

    #region Global_Variale
    public PlayerAttackSystem _player;

    // Basic Value
    [SerializeField] protected float force = 5f;
    [SerializeField] protected float coolTime = 1.0f;

    public float Force { get { return force; } set {  force = value; } }
    public float CoolTime {  get {  return coolTime; } set {  coolTime = value; } }
    #endregion

    private void Awake()
    {
        _player = FindObjectOfType<PlayerAttackSystem>();
    }

    #region Continuation_Item
    protected void BulletDelayLower()
    {
        coolTime -= 0.05f;
    }

    protected void BulletSpeedUp()
    {
        force += 0.5f;
    }
    #endregion

    #region OneTime_Item
    protected void BulletCountUpItem()
    {
        BulletStateReset(_player);
        _player.currentItem = ItemType.BulletUPItem;
    }

    protected void BulletPenetrateItem()
    {
        BulletStateReset(_player);
        _player.currentItem = ItemType.PenetrateItem;
    }

    protected void BulletBounceItem()
    {
        BulletStateReset(_player);
        _player.currentItem = ItemType.BounceItem;
    }

    protected void BulletGuidedMissileItem()
    {
        BulletStateReset(_player);
        _player.currentItem = ItemType.GuidedMissileItem;
    }
    #endregion

    private void BulletStateReset(PlayerAttackSystem player)
    {
        player.itemDuration = 0f;
        player.itemDuration = 5;
    }


    /*
    public event Action<PlayerAttackSystem> OnItemUseEvent;

    public void CallItemUseEvent(PlayerAttackSystem player)
    {
        OnItemUseEvent?.Invoke(player);
    }
    protected void BulltUpItem(PlayerAttackSystem player)
    {
        if (player.currentItem != ItemType.BulletUPItem)
        {
            player.currentItem = ItemType.BulletUPItem;
            StartCoroutine(ItemTime(5.0f, player));
        }
    }

    public IEnumerator ItemTime(float time, PlayerAttackSystem player)
    {
        float timeRemained = time;
        while (timeRemained > 0.0f)
        {
            //if (current != this.currentItem) yield break;
            timeRemained -= Time.deltaTime;
            yield return null;
        }
        player.currentItem = ItemType.Normal;
        Debug.Log("��");
    }
    */
}
