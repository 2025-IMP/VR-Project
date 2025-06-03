using UnityEngine;

public class RailGun : MonoBehaviour, IAttackStrategy
{
    [SerializeField] private Transform shootTransform;

    [SerializeField] private GameObject normalBullet;
    [SerializeField] private GameObject explosionBullet;

    private IShootStrategy m_CurrShootStrategy;

    private IShootStrategy m_NormalShootStrategy;
    private IShootStrategy m_ExplosionShootStrategy;

    private int m_Damage = 1;
    private float m_PowerRatio = 1f;
    private float m_BulletSpeed = 60f;
    private int m_BulletCount = 1;

    private void Awake()
    {
        m_NormalShootStrategy ??= new NormalShootStrategy(normalBullet);
        m_ExplosionShootStrategy ??= new NormalShootStrategy(explosionBullet);
    }

    private void Start()
    {
        m_CurrShootStrategy = m_NormalShootStrategy;
    }

    public void Shoot()
    {
        m_CurrShootStrategy?.Shoot(shootTransform, m_Damage, m_BulletSpeed, m_BulletCount);
    }

    public void Execute()
    {
        Shoot();
    }

    public void AddPowerRatio(float value)
    {
        m_PowerRatio += value * 0.01f;
    }

    public void AddBulletCount(int value)
    {
        m_BulletCount += value;
    }
}
