using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public UIManager _uiManager;
    private int scorePoints = 6; // 0~6까지의 별을 나타내는 점수
    private int maxScore = 6; // 별을 모두 얻을 수 있는 최고 점수

    public GameObject[] stars;
    public GameObject[] halfStars;
    public GameObject[] blackStars;

    private void Awake()
    {
        _uiManager = _uiManager.GetComponent<UIManager>();
    }

    void Update()
    {
        // 플레이어가 얻은 점수 받아옴
        int playerScore = _uiManager.scoreText;

        // playerScore 범위에 따라 scorePoints 설정(현재는 0 ~ 12000)
        if (playerScore >= 0 && playerScore < 2200)
        {
            scorePoints = 0;
        }
        else if (playerScore >= 2200 && playerScore < 4000)
        {
            scorePoints = 1;
        }
        else if (playerScore >= 4000 && playerScore < 6000)
        {
            scorePoints = 2;
        }
        else if (playerScore >= 6000 && playerScore < 8000)
        {
            scorePoints = 3;
        }
        else if (playerScore >= 8000 && playerScore < 10000)
        {
            scorePoints = 4;
        }
        else if (playerScore >= 10000 && playerScore < 12000)
        {
            scorePoints = 5;
        }
        else if (playerScore >= 12000)
        {
            scorePoints = 6;
        }
        else
        {
            scorePoints = 0;
        }



        // scorePoints가 maxScore보다 크게 설정할 경우
        if (scorePoints > maxScore)
        {
            scorePoints = maxScore;
        }

        for (int i = maxScore; i > 0; i--)
        {
            if (i % 2 == 0)
            {
                if (scorePoints < i)
                {
                    stars[i / 2 - 1].SetActive(false);
                    blackStars[i / 2 - 1].SetActive(true);
                    halfStars[i / 2 - 1].SetActive(false);
                }
                else
                {
                    stars[i / 2 - 1].SetActive(true);
                    blackStars[i / 2 - 1].SetActive(false);
                    halfStars[i / 2 - 1].SetActive(false);
                }
            }
            else
            {
                if (scorePoints == i)
                {
                    halfStars[i / 2].SetActive(true);
                }
            }
        }
    }
}
