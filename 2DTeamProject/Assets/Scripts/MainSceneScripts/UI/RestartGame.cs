using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainScene");
    }
}