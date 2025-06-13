using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private Slider m_BGMSlider;
    [SerializeField] private Slider m_SFXSlider;

    private void OnEnable()
    {
        m_BGMSlider.value = AudioManager.Instance.BGMVolume;
        m_SFXSlider.value = AudioManager.Instance.SFXVolume;
    }

    public void OnBGMSliderChanged()
    {
        float value = m_BGMSlider.value;
        AudioManager.Instance.SetVolume(AudioType.BGM, value);
        PlayerPrefs.SetFloat("bgm", value);
    }
    public void OnSFXSliderChanged()
    {
        float value = m_SFXSlider.value;
        AudioManager.Instance.SetVolume(AudioType.SFX, value);
        PlayerPrefs.SetFloat("sfx", value);
    }
}
