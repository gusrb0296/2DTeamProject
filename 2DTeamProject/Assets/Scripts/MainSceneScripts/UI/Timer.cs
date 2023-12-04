using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float limit = 10f;

    public TextMeshProUGUI timeTxt;
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        timeTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        limit -= Time.deltaTime;

        if (limit <= 0.0f)
        {
            limit = 0.0f;
            //endPanel.SetActive(true);
            //Time.timeScale = 0.0f;
        }

        timeTxt.text = "½Ã°£ : " + limit.ToString("N2");
    }
}
