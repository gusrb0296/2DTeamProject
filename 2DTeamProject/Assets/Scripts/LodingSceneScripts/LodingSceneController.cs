using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LodingSceneController : MonoBehaviour
{
    static string nextScene;

    [SerializeField] Image progressBar;

    // static으로 선언된 함수의 내부에서는 static으로 선언되지 않은 일반 멤버변수나 함수는 바로 호출이 불가능
    // static : 정적, 하나의 메모리
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
                timer += Time.deltaTime;
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

/*
IEnumerator LoadScene()
{
    yield return null;

    AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
    op.allowSceneActivation = false;

    float timer = 0.0f;
    while (!op.isDone)
    {
        yield return null;

        timer += Time.deltaTime; 
        if (op.progress < 0.9f) 
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
            if (progressBar.fillAmount >= op.progress) 
            {
                timer = 0f;
            }
        } 
        else 
        {
            progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 
            if (progressBar.fillAmount == 1.0f)
            {
                op.allowSceneActivation = true; 
                yield break; 
            } 
        }
    }
}
*/

/*
    IEnumerator LoadSceneProgress()
    {
        // LoadScene은 동기방식 Scene불러오기 기능이라 Scene을 다 불러오기 전까지는 다른 작업을 할 수가 없다.
        // LoadSceneAsync는 비동기방식으로 Scene을 불러오는 도중 다른 작업이 가능하다.
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        // Scene을 비동기로 불러들일 때, Scene의 로딩이 끝나면 자동으로 불러올 Scene으로 이동할 것인지 설정.
        // false로 하면 Scene을 자동으로 넘기지 않고 90% 까지만 로드한 상태로 다음 Scene으로 넘어가지 않은 상태로 기다리게 되며
        // 다시 allowSceneActivation을 true로 변경하면 그 때 남은 부분을 마저 로드하고 넘어가게 된다.
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)  // !isDone : 아직 로딩이 끝나지 않은 상태라면.
        {
            // 반복문이 한번 반복돌 때 마다 유니티엔진의 제어권을 넘기도록 한다.
            // 이런식으로 반복문이 돌 때마다 제어권을 넘겨주지 않으면 반복문이 끝나기 전에는 화면이 갱신x , 그래서 진행바 차는게 보이지 않는다.
            yield return null;

            if (op.progress < 0.9f) // 실제 로딩
            {
                progressBar.fillAmount = op.progress;
            }
            else  // 페이크 로딩
            {
                // UnScaledDeltaTime : 크기가 조정되지 않은 델타 타임.
                // 유니티에서는 Time Scale이라는 요소가 있는데 이 time scale을 조절하면 1일 때는 현실과 같은 속도로, 1보다 작으면 현실보다 느리게, 1보다 크면 현실보다 빠르게 시간이 흐르게 된다.
                // 이 Time scale에 DeltaTime이 영향을 받아서 시간이 느리거나 빠르게 흘러가는 효과를 줄 수 있다.
                // 하지만 이 time scale에 영향을 받지 않고 움직여야 하는 요소 역시 게임에 존재할 수 있는데 이때  그 영향을 받지 않는 값이 Unscaled Delta Time 이다.
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);   // 0.9 ~ 1까지 1초에 걸쳐 채우기
                if (progressBar.fillAmount >= 1f)
                {
                    // progressBar가 다 채워지면 true로 바꿔준다.
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            
        }
*/


