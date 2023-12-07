using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;

    void Update()
    {
        // 마우스 클릭 또는 ESC 키를 눌렀을 때
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() || Input.GetKeyDown(KeyCode.Escape))
        {
            ActivePausePanel();
        }
    }

    public void ActivePausePanel()
    {
        Invoke("OnPauseButtonClick", 0.5f);
    }

    private void OnPauseButtonClick()
    {
        // 판넬을 활성화
        if (pausePanel != null)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
