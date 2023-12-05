using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public int playerScore; // 플레이어가 얻은 점수
    private int scorePoints = 6; // 0~6까지의 별을 나타내는 점수
    private int maxScore = 6; // 별을 모두 얻을 수 있는 최고 점수

    public GameObject[] stars;
    public GameObject[] halfStars;
    public GameObject[] blackStars;


    void Update()
    {
        // playerScore 범위에 따라 scorePoints 설정(현재는 0 ~ 60)
        if (playerScore >= 0 && playerScore < 10)
        {
            scorePoints = 0;
        }
        else if (playerScore >= 10 && playerScore < 20)
        {
            scorePoints = 1;
        }
        else if (playerScore >= 20 && playerScore < 30)
        {
            scorePoints = 2;
        }
        else if (playerScore >= 30 && playerScore < 40)
        {
            scorePoints = 3;
        }
        else if (playerScore >= 40 && playerScore < 50)
        {
            scorePoints = 4;
        }
        else if (playerScore >= 50 && playerScore < 60)
        {
            scorePoints = 5;
        }
        else if (playerScore >= 60)
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
