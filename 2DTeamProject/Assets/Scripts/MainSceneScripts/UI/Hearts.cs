using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        // health가 numOfHearts보다 크게 설정할 경우
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {
            // 꽉 찬 하트와 빈 하트 표시
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }


            // numOfHearts의 개수만큼 표시되는 총 hearts 이미지 개수
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void DecreaseHealth(int amount)
    {
        health -= amount;
    }
}
