using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHitByBall : Hearts
{
    [SerializeField] private SpriteRenderer _sprite;
    private void Awake()
    {
        _sprite = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball") // 볼중에서 큰 공 / 미들 공 / 작은 공 : 태그수정필요
        {
            // 하트 감소
            DecreaseHealth(1);

            // 피격 효과
            StartCoroutine(HitPlayer(_sprite, 0.1f));

            // 사망 애니메이션 후 종료 판넬
            //ShowDieAnim();
            //ShowFailurePanel();
        }


    }
    IEnumerator HitPlayer(SpriteRenderer sprite, float delay)
    {
        sprite.color = new Color32(255, 0, 0, 200);
        yield return new WaitForSeconds(delay);
        sprite.color = new Color32(255, 255, 255, 255);
    }
}
