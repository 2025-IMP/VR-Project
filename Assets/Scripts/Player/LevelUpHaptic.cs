using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Feedback;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Haptics;

public class LevelUpHaptic : MonoBehaviour
{
    [SerializeField] private HapticImpulsePlayer m_HapticImpulsePlayer;
    [SerializeField] private HapticImpulseData m_HapticData = new HapticImpulseData
    {
        amplitude = 0.8f,
        duration = 0.3f,
        frequency = 0f
    };

    public void PlayHapticFeedback()
    {
        if (m_HapticImpulsePlayer == null)
            m_HapticImpulsePlayer = GetComponent<HapticImpulsePlayer>();

        if (m_HapticImpulsePlayer != null)
            m_HapticImpulsePlayer.SendHapticImpulse(m_HapticData.amplitude, m_HapticData.duration, m_HapticData.frequency);
    }
}

