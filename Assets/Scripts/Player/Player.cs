using IMP.Core;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHealth m_Health;
    private PlayerShooter m_Shooter;
    private PlayerLevel m_Level;

    private void Awake()
    {
        m_Health = GetComponent<PlayerHealth>();
        m_Shooter = GetComponent<PlayerShooter>();
        m_Level = GetComponent<PlayerLevel>();
    }

    private void Start()
    {
        m_Level.Initialize();
    }

    public void GainExp(int exp)
    {
        m_Level.GainExp(exp);
    }
}
