using UnityEngine;

public class ActivePanel : MonoBehaviour
{
    public GameObject panel;

    public void ActivePanels()
    {
        Invoke("ActivatePanel", 0.5f);
    }
    public void DeactivePanels()
    {
        Invoke("DeactivatePanel", 0.5f);
    }

    private void ActivatePanel()
    {
        panel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void DeactivatePanel()
    {
        panel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}