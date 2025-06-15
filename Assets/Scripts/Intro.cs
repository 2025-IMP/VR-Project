using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject m_IntroPanel;
    [SerializeField] private GameObject m_SettingsPanel;

    private void Start()
    {
        AudioManager.Instance.PlayAudio(AudioType.BGM, AudioManager.Instance.titleBGM);
        m_IntroPanel.SetActive(true);
        m_SettingsPanel.SetActive(false);
    }

    public void OnStartPressed()
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.clickSFX);
        SceneManager.LoadScene("Game");
    }

    public void OnSettingsPressed()
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.clickSFX);
        m_IntroPanel.SetActive(false);
        m_SettingsPanel.SetActive(true);
    }

    public void OnExitPressed()
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.clickSFX);
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnBackPressed()
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.clickSFX);
        m_IntroPanel.SetActive(true);
        m_SettingsPanel.SetActive(false);
    }
}
