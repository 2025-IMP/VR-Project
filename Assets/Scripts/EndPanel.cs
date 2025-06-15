using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text m_ResultText;

    public void Show(float elapsedTime)
    {
        int min = (int)(elapsedTime / 60f);
        int sec = (int)(elapsedTime % 60);

        m_ResultText.text = $"Result Time: {min.ToString().PadLeft(2, '0')}:{sec.ToString().PadLeft(2, '0')}";
    }

    public void OnEndPressed()
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.clickSFX);
        SceneManager.LoadScene("Intro");
    }
}
