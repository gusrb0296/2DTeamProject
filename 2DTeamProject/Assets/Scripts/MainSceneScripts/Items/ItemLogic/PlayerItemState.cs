using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemState : MonoBehaviour
{
    #region ItemTypeEnum
    public enum ItemType
    {
        Normal,
        BulletUPItem,       // bullet 갯수 증가
        PenetrateItem,      // 관통
        BounceItem,         // 튕김
        GuidedMissileItem   // 유도탄
    }

    // ItemType Reset Value
    public ItemType currentItem;

    #endregion

    #region Global_Variale

    public PlayerAttackSystem _player;

    // Item Use DurationTime
    public float itemDuration = 0f;

    #endregion

    private void Awake()
    {
        _player = FindObjectOfType<PlayerAttackSystem>();
    }

    #region Continuation_Item
    public void BulletDelayLower()
    {
        BulletStateCheck();
    }

    #region Continuation_Item

    public void BulletSpeedUp()
    {
        _player.Force += 0.5f;
    }
    #endregion

    #region OneTime_Item
    public void BulletCountUpItem()
    {
        BulletStateReset(_player);
        currentItem = ItemType.BulletUPItem;
    }

    public void BulletPenetrateItem()
    {
        BulletStateReset(_player);
        currentItem = ItemType.PenetrateItem;
    }

    public void BulletBounceItem()
    {
        BulletStateReset(_player);
        currentItem = ItemType.BounceItem;
    }

    public void BulletGuidedMissileItem()
    {
        BulletStateReset(_player);
        currentItem = ItemType.GuidedMissileItem;
    }
    #endregion

    public void BulletCoolTimeReset()
    {
        _player.CoolTimeCheck = true;
    }

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

    private void BulletStateReset(PlayerAttackSystem player)
    {
        itemDuration = 0f;
        itemDuration = 5;
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
        Debug.Log("끝");
    }
    */
}
