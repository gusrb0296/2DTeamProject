using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] Backgroundsprites;
    public Image BackgroundPanel;

    private void Awake()
    {
        BackgroundPanel.sprite = Backgroundsprites[PlayerPrefs.GetInt("GameLevel") - 1];
    }
    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Ball") == null)
        {
            Debug.Log("게임 클리어");
        }
    }
}
