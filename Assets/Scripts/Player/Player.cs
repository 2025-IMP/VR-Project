using IMP.Core;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerHealth m_Health;
    private PlayerShooter m_Shooter;
    private PlayerLevel m_Level;
    private PlayerAbility m_Ability;

    private void Awake()
    {
        m_Health = GetComponent<PlayerHealth>();
        m_Shooter = GetComponent<PlayerShooter>();
        m_Level = GetComponent<PlayerLevel>();
        m_Ability = GetComponent<PlayerAbility>();
    }

    private void Start()
    {
        m_Level.Initialize();
        m_Ability.Initialize();
    }

    public void GainExp(int exp)
    {
        m_Level.GainExp(exp);
    }

    public void PowerUpRailgunPower(float value)
    {
        m_Shooter.Gun.AddPowerRatio(value);
    }
    
    public void PowerUpRailgunBullet(int value)
    {

    }
}
