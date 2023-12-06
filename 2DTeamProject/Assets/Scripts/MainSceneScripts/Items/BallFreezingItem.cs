using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFreezingItem : MonoBehaviour
{
    PlayerItemState _playerItemState;

    private void Awake()
    {
        _playerItemState = FindObjectOfType<PlayerItemState>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _playerItemState.BallFreezingItem();

            Destroy(gameObject);    // 추후 오브젝트 풀링
        }
    }
}
