using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _BallPrefabs;
    public UIManager _uiManager;

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
    private void Update()
    {
        _uiManager.GameOver(); //update문에다 사용시 너무 낭비되니깐 공피격시로 옮기기
    }

    public void BallPorduce() // 공생성
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
    } //난이도에 따른 공생성 갯수

}
