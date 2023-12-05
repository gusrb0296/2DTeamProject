using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public int playerHealth = 10; // 0~10까지의 플레이어 하트(체력)를 나타냄
    private int maxHealth = 10; // 하트를 모두 얻을 수 있는 최고 체력

    public GameObject[] hearts;
    public GameObject[] halfHearts;
    public GameObject[] blackHearts;


    void Update()
    {
        // playerHealth가 maxHealth보다 크게 설정할 경우
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
        }

        for (int i = maxHealth; i > 0; i--)
        {
            if (i % 2 == 0)
            {
                if (playerHealth < i)
                {
                    hearts[i / 2 - 1].SetActive(false);
                    blackHearts[i / 2 - 1].SetActive(true);
                    halfHearts[i / 2 - 1].SetActive(false);
                }
                else
                {
                    hearts[i / 2 - 1].SetActive(true);
                    blackHearts[i / 2 - 1].SetActive(false);
                    halfHearts[i / 2 - 1].SetActive(false);
                }
            }
            else
            {
                if (playerHealth == i)
                {
                    halfHearts[i / 2].SetActive(true);
                }
            }
        }
    }
    public void DecreaseHealth(int amount)
    {
        playerHealth -= amount;
    }
}
