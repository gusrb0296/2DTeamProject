using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnClickSound : MonoBehaviour
{
    [SerializeField] private Button _pauseBtn;
    [SerializeField] private Button _resumeBtn;
    [SerializeField] private Button _restartBtn;
    [SerializeField] private Button _exitBtn;
    [SerializeField] private Button _retryBtn1;
    [SerializeField] private Button _homeBtn1;
    [SerializeField] private Button _retryBtn2;
    [SerializeField] private Button _homeBtn2;

    public AudioSource _btnSource;

    private void Awake()
    {
        _pauseBtn.onClick.AddListener(() => _btnSource.Play());
        _resumeBtn.onClick.AddListener(() => _btnSource.Play());
        _restartBtn.onClick.AddListener(() => { _btnSource.Play(); LoadScene("MainScene"); });
        _exitBtn.onClick.AddListener(() => { _btnSource.Play(); QuitGame(); });
        _retryBtn1.onClick.AddListener(() => { _btnSource.Play(); LoadScene("MainScene"); });
        _homeBtn1.onClick.AddListener(() => { _btnSource.Play(); LoadScene("StartScene"); });
        _retryBtn2.onClick.AddListener(() => { _btnSource.Play(); LoadScene("MainScene"); });
        _homeBtn2.onClick.AddListener(() => { _btnSource.Play(); LoadScene("StartScene"); });
    }

    private void LoadScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
        //게임 매니져한테 index값 넘겨주면 해당하는 Enum값 설정하게
    }
    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
