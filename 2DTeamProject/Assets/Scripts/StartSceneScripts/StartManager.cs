using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameSetting;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _closeBtn;

    private void Awake()
    {
        Button _gameSettingBtn = _gameSetting.GetComponent<Button>();

        _startBtn.onClick.AddListener(() => LoadScene());
        _closeBtn.onClick.AddListener(() => SettingWindow(false));
        _gameSettingBtn.onClick.AddListener(() => SettingWindow(true));
    }

    private void SettingWindow(bool istrue)
    {
        _gameSetting.transform.GetChild(1).gameObject.SetActive(istrue);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
