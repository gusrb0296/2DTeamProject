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
        Time.timeScale = 0.0f;
        panel.SetActive(true);
    }

    private void DeactivatePanel()
    {
        Time.timeScale = 1.0f;
        panel.SetActive(false);
    }
}