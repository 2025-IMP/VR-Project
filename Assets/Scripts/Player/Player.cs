using IMP.Core;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player PlayerInstance { get; private set; }

    private PlayerHealth m_Health;
    public PlayerHealth Health => m_Health;
    private PlayerShooter m_Shooter;
    private PlayerLevel m_Level;
    private PlayerAbility m_Ability;
    public PlayerAbility Ability => m_Ability;

    private float m_BaseSpeed = 3f;

    private float m_PowerRatio = 1f;
    public float PowerRatio => m_PowerRatio;

    private float m_SpeedRatio = 1f;
    public float SpeedRatio => m_SpeedRatio;

    private float m_HealthRatio = 1f;
    public float HealthRatio => m_HealthRatio;

    private float m_ProtectRatio = 1f;
    public float ProtectRatio => m_ProtectRatio;

    private void Awake()
    {
        m_Health = GetComponent<PlayerHealth>();
        m_Shooter = GetComponent<PlayerShooter>();
        m_Level = GetComponent<PlayerLevel>();
        m_Ability = new PlayerAbility(this);

        PlayerInstance = this;
    }

    private void Start()
    {
        m_Level.Initialize();
        m_Ability.Initialize();

        m_Shooter.MoveProvider.moveSpeed = m_BaseSpeed;
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
        m_Shooter.Gun.AddBulletCount(value);
    }

    public void PowerUpRailgunExplosion(float value)
    {
        // Activate explosion.
        if (value == 0)
        {
            m_Shooter.Gun.SetShootStrategy(true);
        }
        // Enhance explosion power.
        else
        {
            m_Shooter.Gun.AddBulletExplosionPowerRatio(value);
        }
    }

    public void PowerUpRailgunThrough(int value)
    {
        m_Shooter.Gun.AddBulletThroughCount(value);
    }

    public void PowerUpPassivePower(float value)
    {
        m_PowerRatio += value * 0.01f;
    }

    public void PowerUpPassiveSpeed(float value)
    {
        m_SpeedRatio += value * 0.01f;
        m_Shooter.MoveProvider.moveSpeed = m_BaseSpeed * m_SpeedRatio;
    }

    public void PowerUpPassiveHealth(float value)
    {
        m_HealthRatio += value * 0.01f;
        m_Health.ApplyHealthRatio(m_HealthRatio);
    }

    public void PowerUpPassiveProtect(float value)
    {
        m_ProtectRatio -= value * 0.01f;
    }
}
