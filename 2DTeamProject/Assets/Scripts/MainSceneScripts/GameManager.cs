using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _BallPrefabs;

    int _GameLevelIndex;
    int _ballCount;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        _GameLevelIndex = PlayerPrefs.GetInt("GameLevel");
    }

    private void Start()
    {
        BallPorduce();
        InvokeRepeating("BallSpawn", 5, 7);
    }

    public void BallPorduce() // ������
    {
        for (int i = 0; i < _GameLevelIndex; i++)
        {
            Instantiate(_BallPrefabs);
        }
    }
    public void BallSpawn()
    {
        Instantiate(_BallPrefabs);
        _ballCount++;

        if (_ballCount == _GameLevelIndex)
        {
            CancelInvoke("BallSpawn");
        }
        else if (_ballCount == _GameLevelIndex)
        {
            CancelInvoke("BallSpawn");
        }
        else if(_ballCount == _GameLevelIndex)
        {
            CancelInvoke("BallSpawn");
        }
    } //���̵��� ���� ������ ����
}
