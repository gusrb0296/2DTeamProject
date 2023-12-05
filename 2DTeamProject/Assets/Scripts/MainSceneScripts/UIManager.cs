using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject _clearPanel;
    public GameObject _gameoverPanel;
    public Sprite[] Backgroundsprites;
    public Image BackgroundPanel;

    private void Awake()
    {
        BackgroundPanel.sprite = Backgroundsprites[PlayerPrefs.GetInt("GameLevel") - 1];
    }
    public void GameOver()
    {
        if (GameObject.FindGameObjectsWithTag("Ball").Length == 0)
        {
            Time.timeScale = 0;
            _clearPanel.gameObject.SetActive(true);
        }
        //else if ()
        //{
        //    Time.timeScale = 0;
        //    _gameoverPanel.gameObject.SetActive(true);
        //}
    }
}
