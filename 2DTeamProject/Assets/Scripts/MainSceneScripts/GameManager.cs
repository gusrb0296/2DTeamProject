using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject _BallPrefabs;
    public GameObject _countDown;
    public UIManager _uiManager;

    public float _time; //시간저장

    int _GameLevelIndex;
    int _ballCount;
    bool isGameOverCalled = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1;
        _uiManager._isGameScore = true;
        _GameLevelIndex = PlayerPrefs.GetInt("GameLevel");
    }

    private void Start()
    {
        SoundManager.instance.SetBGMByGameLevel();
        StartCoroutine("StartDelay");
        BallProduce();
        InvokeRepeating("BallSpawn", 5, 7);
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0 || _uiManager._hearts.playerHealth <= 0)
        {
            if (!isGameOverCalled)
            {
                _uiManager.GameOver(); //update문에다 사용시 너무 낭비되니깐 공피격시로 옮기기
                isGameOverCalled = true;
            }
        }
        _time += Time.deltaTime;
        _uiManager._timeText.text = $"시간 : {"<color=#4EFF8B>" + (int)_time + "</color>"}";
        _uiManager._ScoreText.text = $"점수 : {"<color=#FFD853>" + _uiManager.scoreText + "</color>"}";
    }

    public void BallProduce() // 공생성
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



    IEnumerator StartDelay()
    {
        Time.timeScale = 0;
        float pauseTime = Time.realtimeSinceStartup + 3f;
        while (Time.realtimeSinceStartup < pauseTime)
            yield return 0;
        _countDown.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
