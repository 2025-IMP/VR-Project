using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject m_IntroPanel;
    [SerializeField] private GameObject m_SettingsPanel;

    private void Start()
    {
        m_IntroPanel.SetActive(true);
        m_SettingsPanel.SetActive(false);
    }

    public void OnStartPressed()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsPressed()
    {
        m_IntroPanel.SetActive(false);
        m_SettingsPanel.SetActive(true);
    }

    public void OnExitPressed()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnBackPressed()
    {
        m_IntroPanel.SetActive(true);
        m_SettingsPanel.SetActive(false);
    }
}
