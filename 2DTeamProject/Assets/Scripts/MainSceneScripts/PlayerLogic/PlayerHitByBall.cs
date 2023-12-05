using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHitByBall : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ball")
            StartCoroutine(HitPlayer(_sprite, 0.1f)); // 피격 효과
    }
    IEnumerator HitPlayer(SpriteRenderer sprite, float delay)
    {
        sprite.color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(delay);
        sprite.color = new Color32(255, 255, 255, 255);
    }
}
