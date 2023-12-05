using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private float time = 0f;
    public TextMeshProUGUI timeTxt;
    public GameObject endPanel;

    void Update()
    {
        time += Time.deltaTime;

        //if (/*게임오버*/)
        //{
        //    endPanel.SetActive(true);
        //    Time.timeScale = 0;
        //}

        timeTxt.text = "시간 : " + time.ToString("N2");
    }
}
