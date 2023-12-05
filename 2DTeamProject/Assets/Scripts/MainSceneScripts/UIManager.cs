using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _clearPanel;
    public GameObject _gameoverPanel;
    public TextMeshProUGUI _clearScore;
    public TextMeshProUGUI _gameoverScore;
    public TextMeshProUGUI _timeText;
    public Sprite[] Backgroundsprites;
    public Image BackgroundPanel;

    string scoreText = "";

    private void Awake()
    {
        BackgroundPanel.sprite = Backgroundsprites[PlayerPrefs.GetInt("GameLevel") - 1];
    }
    public void GameOver()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            Time.timeScale = 0;
            GameScore();
            _clearPanel.gameObject.SetActive(true);
        }
        //else if ()
        //{
        //    Time.timeScale = 0;
        //    GameScore();
        //    _gameoverPanel.gameObject.SetActive(true);
        //}
    }
    public void GameScore()
    {
        int _time = (int)GameManager.instance._time;

        //조건을 넣어 GameOver시 다른 점수를 넣을 수 있도록 적용해야함
        switch (PlayerPrefs.GetInt("GameLevel"))
        {
            case 1:
                scoreText = (((_time < 40) ? 50 - _time : 10) * 200 /*플레이어의 체력  * 1000*/).ToString();
                break;
            case 2:
                scoreText = (((_time < 60) ? 70 - _time : 10) * 200 /*플레이어의 체력  * 1000*/).ToString();
                break;
            case 3:
                scoreText = (((_time < 80) ? 90 - _time : 10) * 200 /*플레이어의 체력  * 1000*/).ToString();
                break;
        }
        _gameoverScore.text = scoreText;
        _clearScore.text = scoreText;
    }
}
