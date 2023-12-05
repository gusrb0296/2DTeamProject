using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void RestartScene()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;
    }
}