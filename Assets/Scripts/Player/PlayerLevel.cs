using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private PlayerExpSlider m_Slider;

    private int m_Exp;
    private int m_Level;
    private int m_NeedExp;

    // 이벤트 이름 정리
    public static Action OnLevelUp;
    public static Action<XRBaseInputInteractor> OnLevelUpWithInteractor;

    public void Initialize()
    {
        m_Exp = 0;
        m_Level = 1;
        m_NeedExp = GetNeedExp(m_Level);
    }

    // 기본 경험치 증가
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

    // interactor와 함께 경험치 증가
    public void GainExp(int exp, XRBaseInputInteractor interactor)
    {
        m_Exp += exp;

        if (m_Exp >= m_NeedExp)
        {
            LevelUp(interactor);
            m_Exp -= m_NeedExp;
        }

        float ratio = (float)m_Exp / m_NeedExp;
        m_Slider.ApplyChanges(m_Level, m_NeedExp - m_Exp, ratio);
    }

    // 기본 레벨업
    private void LevelUp()
    {
        m_Level += 1;
        m_NeedExp = GetNeedExp(m_Level);

        // 진동 실행
        FindObjectOfType<LevelUpHaptic>()?.PlayHapticFeedback();

        // 이벤트 실행
        OnLevelUp?.Invoke();
    }

    // interactor 기반 레벨업
    private void LevelUp(XRBaseInputInteractor interactor)
    {
        m_Level += 1;
        m_NeedExp = GetNeedExp(m_Level);

        // 진동 실행
        FindObjectOfType<LevelUpHaptic>()?.PlayHapticFeedback();

        // 이벤트 실행
        OnLevelUpWithInteractor?.Invoke(interactor);
    }

    // 필요 경험치 계산
    public int GetNeedExp(int level)
    {
        return 3 + level * 2;
    }
}
