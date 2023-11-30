using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public GameObject panel;

    public void ActivatePanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void DeactivatePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}