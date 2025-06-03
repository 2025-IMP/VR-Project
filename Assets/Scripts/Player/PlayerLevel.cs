using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private PlayerExpSlider m_Slider;

    private int m_Exp;
    private int m_Level;

    private int m_NeedExp;

    public void Initialize()
    {
        m_Exp = 0;
        m_Level = 1;
        m_NeedExp = GetNeedExp(m_Level);
    }

    public void GainExp(int exp)
    {
        m_Exp += exp;

        if (m_Exp >= m_NeedExp)
        {
            LevelUp();
            m_Exp -= m_NeedExp;
        }

        float ratio = (float)m_Exp / m_NeedExp;

        m_Slider.ApplyChanges(m_Level, m_NeedExp - m_Exp, ratio);
    }

    private void LevelUp()
    {
        m_Level += 1;
        m_NeedExp = GetNeedExp(m_Level);
    }

    public int GetNeedExp(int level)
    {
        return 3 + level * 2;
    }
}
