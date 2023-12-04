using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject _Canvas;
    [SerializeField] private GameObject _muteOn;
    [SerializeField] private GameObject _muteOff;
    [SerializeField] private GameObject _Guide;
    [SerializeField] private Button _gameSettingBtn;
    [SerializeField] private Button _startBtn;
    [SerializeField] private Button _closeBtn;
    [SerializeField] private Button _LevelBtn;
    [SerializeField] private Button _easyBtn;
    [SerializeField] private Button _normalBtn;
    [SerializeField] private Button _hardBtn;
    [SerializeField] private Button _guideCloseBtn;
    [SerializeField] private Button _ExitBtn;



    public Slider _soundSlider;

    public AudioSource _audioSource;
    public AudioSource _btnSource;

    private void Awake()
    {
        Button _muteOnBtn = _muteOn.GetComponent<Button>();
        Button _muteOffBtn = _muteOff.GetComponent<Button>();
        Button _guideOpenBtn = _Guide.transform.parent.GetComponent<Button>();


        _startBtn.onClick.AddListener(() => { LevelWindow(true); _btnSource.Play(); });
        _closeBtn.onClick.AddListener(() => { SettingWindow(false); _btnSource.Play(); });
        _gameSettingBtn.onClick.AddListener(() => { SettingWindow(true); _btnSource.Play(); });
        _LevelBtn.onClick.AddListener(() => { LevelWindow(false); _btnSource.Play(); });
        _easyBtn.onClick.AddListener(() => LoadScene(1));
        _normalBtn.onClick.AddListener(() => LoadScene(2));
        _hardBtn.onClick.AddListener(() => LoadScene(3));
        _muteOnBtn.onClick.AddListener(() => { MuteSystem(true, false); _btnSource.Play(); });
        _muteOffBtn.onClick.AddListener(() => { MuteSystem(false, true); _btnSource.Play(); });
        _guideOpenBtn.onClick.AddListener(() => { GuideWindow(true); _btnSource.Play(); });
        _guideCloseBtn.onClick.AddListener(() => { GuideWindow(false); _btnSource.Play(); });
        _ExitBtn.onClick.AddListener(() => { EndGame(); _btnSource.Play(); });
    }


    private void Update()
    {
        SoundSystem(_soundSlider.value);
    }

    private void GuideWindow(bool istrue)
    {
        _Guide.gameObject.SetActive(istrue);
    }
    private void SoundSystem(float value)
    {
        _audioSource.volume = value;
    }
    private void MuteSystem(bool isMuteOn, bool isMuteOff)
    {
        _audioSource.mute = isMuteOn;
        _muteOn.transform.GetChild(0).gameObject.SetActive(isMuteOn);
        _muteOff.transform.GetChild(0).gameObject.SetActive(isMuteOff);
    }
    private void SettingWindow(bool istrue)
    {
        _Canvas.transform.Find("SettingBackGround").gameObject.SetActive(istrue);
    }
    private void LevelWindow(bool istrue)
    {
        _Canvas.transform.Find("LevelBackGround ").gameObject.SetActive(istrue);
    }
    private void LoadScene(int index)
    {
        PlayerPrefs.SetInt("GameLevel", index);
        SceneManager.LoadScene("MainScene");
    }
    private void EndGame()
    {
        Application.Quit();
    }
}
