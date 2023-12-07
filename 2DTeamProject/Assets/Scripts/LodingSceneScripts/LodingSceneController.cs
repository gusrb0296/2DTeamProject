using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LodingScene");
    }

    void Start()
    {
        StartCoroutine(LoadSceneProgress());
    }

    IEnumerator LoadSceneProgress()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)  // !isDone : 아직 로딩이 끝나지 않은 상태라면.
        {
            yield return null;

            if (op.progress < 0.9f) // 실제 로딩
            {
                progressBar.fillAmount = op.progress;
            }
            else  // 페이크 로딩
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);   
                if (progressBar.fillAmount >= 1f)
                {
                    // progressBar가 다 채워지면 true로 바꿔준다.
                    op.allowSceneActivation = true;
                    yield break;
                }
            }

        }
    }
}


