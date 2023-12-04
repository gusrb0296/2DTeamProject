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
        BulletUPItem,       // bullet °¹¼ö Áõ°¡
        PenetrateItem,      // °üÅë
        BounceItem,         // Æ¨±è
        GuidedMissileItem   // À¯µµÅº
    }
    #endregion

    #region Global_Variale
    protected PlayerAttackSystem _player;

    // Basic Value
    [SerializeField] protected float force = 5;
    [SerializeField] protected float coolTime = 1.0f;
    #endregion

    #region Continuation_Item
    protected void BulletDelayLower(PlayerAttackSystem player)
    {
        player.coolTime -= 0.05f;
    }

    protected void BulletSpeedUp(PlayerAttackSystem player)
    {
        player.force += 0.5f;
    }
    #endregion

    #region OneTime_Item
    protected void BulletCountUpItem(PlayerAttackSystem player)
    {
        _player.itemDuration = 0f;
        _player.itemDuration = 5.0f;
        _player.currentItem = ItemType.BulletUPItem;
    }

    protected void BulletPenetrateItem(PlayerAttackSystem player)
    {
        _player.itemDuration = 0f;
        _player.itemDuration = 5;
        _player.currentItem = ItemType.PenetrateItem;
    }
    #endregion


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
        Debug.Log("³¡");
    }
    */
}
