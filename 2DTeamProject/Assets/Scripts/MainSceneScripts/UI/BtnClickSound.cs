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
    [SerializeField] private Button _nextLvBtn;
    [SerializeField] private Button _retryBtn2;

    public AudioSource _btnSource;

    private void Awake()
    {
        _pauseBtn.onClick.AddListener(() => _btnSource.Play());
        _resumeBtn.onClick.AddListener(() => _btnSource.Play());
        _restartBtn.onClick.AddListener(() => { _btnSource.Play(); LoadScene(0); });
        _exitBtn.onClick.AddListener(() => { _btnSource.Play(); QuitGame(); });
        _retryBtn1.onClick.AddListener(() => { _btnSource.Play(); LoadScene(0); });
        _nextLvBtn.onClick.AddListener(() => { _btnSource.Play(); LoadScene(1); });
        _retryBtn2.onClick.AddListener(() => { _btnSource.Play(); LoadScene(0); });
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene("MainScene");
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
