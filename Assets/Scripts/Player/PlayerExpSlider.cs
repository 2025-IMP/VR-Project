using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExpSlider : MonoBehaviour
{
    private Slider m_Slider;

    [SerializeField] private TMP_Text m_LevelText;
    [SerializeField] private TMP_Text m_LeftExpText;

    private void Awake()
    {
        m_Slider = GetComponent<Slider>();
    }

    public void ApplyChanges(int level, int leftExp, float ratio)
    {
        m_LevelText.text = $"Level: {level}";
        m_LeftExpText.text = $"Left Exp: {leftExp}";
        m_Slider.value = ratio;
    }
}
