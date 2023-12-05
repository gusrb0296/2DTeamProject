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
    public Hearts _hearts;


    int scoreText = 0;

    private void Awake()
    {
        BackgroundPanel.sprite = Backgroundsprites[PlayerPrefs.GetInt("GameLevel") - 1];
        _hearts = _hearts.GetComponent<Hearts>();
    }
    public void GameOver()
    {
        if (_hearts.playerHealth > 0)
            StartCoroutine(Game());
        else
            StartCoroutine(Game());
    }
    private IEnumerator Game()
    {
        if (_hearts.playerHealth > 0)
        {
            Time.timeScale = 0;
            GameScore();
            _clearPanel.gameObject.SetActive(true);
        }
        else if (_hearts.playerHealth <= 0)
        {
            yield return new WaitForSeconds(2f);
            Time.timeScale = 0;
            GameScore();
            _gameoverPanel.gameObject.SetActive(true);
        }
    }

    public void GameScore()
    {
        int _time = (int)GameManager.instance._time;

        //조건을 넣어 GameOver시 다른 점수를 넣을 수 있도록 적용해야함
        switch (GameManager.instance._time)
        {
            case < 90:
                scoreText += 40 * 100 + _hearts.playerHealth * 200; // 최고점수 4000점 + 2000 = 6000 여기에 공을 뿌셔서 얻은 점수 더하기
                break;
            case < 150:
                scoreText += 30 * 100 + _hearts.playerHealth * 200;
                break;
            case < 210:
                scoreText += 20 * 100 + _hearts.playerHealth * 200;
                break;
            default:
                scoreText += 10 * 100 + _hearts.playerHealth * 200;
                break;
        }
        _gameoverScore.text = scoreText.ToString();
        _clearScore.text = scoreText.ToString();
    }
}
