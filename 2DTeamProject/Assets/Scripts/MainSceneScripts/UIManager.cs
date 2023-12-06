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
    public TextMeshProUGUI _clearScore; //게임승리 Score
    public TextMeshProUGUI _gameoverScore; //게임오버시 Score 
    public TextMeshProUGUI _timeText; // UI시간 
    public TextMeshProUGUI _ScoreText; // UI점수 
    public Sprite[] Backgroundsprites; //난이도 별로 다른 배경
    public Image BackgroundPanel; //배경 이미지에 접근
    public Hearts _hearts;

    public int scoreText = 0;
    public bool _isGameScore = true;
    
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
            SoundManager.instance.StopBGM();
            Time.timeScale = 0;
            GameScore();
            SoundManager.instance.PlaySFX("GameClear");
            _clearPanel.gameObject.SetActive(true);
        }
        else if (_hearts.playerHealth <= 0)
        {
            SoundManager.instance.StopBGM();
            yield return new WaitForSeconds(0.8f);
            Time.timeScale = 0;
            GameScore();
            SoundManager.instance.PlaySFX("GameOver");
            _gameoverPanel.gameObject.SetActive(true);
        }
    }

    public void GameScore()
    {
        int _time = (_hearts.playerHealth > 0) ? (int)GameManager.instance._time : 250;
        int _health = (_hearts.playerHealth > 0) ? _hearts.playerHealth : 0;

        //조건을 넣어 GameOver시 다른 점수를 넣을 수 있도록 적용해야함
        if (_isGameScore)
        {
            _isGameScore = false;
            switch (_time)
            {
                case < 90:
                    scoreText += 40 * 150 + _health * 300; // 최고점수 4000점 + 2000 = 6000 여기에 공을 뿌셔서 얻은 점수 더하기
                    break;
                case < 150:
                    scoreText += 30 * 150 + _health * 300;
                    break;
                case < 210:
                    scoreText += 20 * 150 + _health * 300;
                    break;
                default:
                    scoreText += 10 * 150 + _health * 300;
                    break;
            }   
        }
        _gameoverScore.text = scoreText.ToString();
        _clearScore.text = scoreText.ToString();
    }
}
