using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class RailGun : MonoBehaviour, IAttackStrategy
{
    [SerializeField] private Transform shootTransform;

    [SerializeField] private Bullet normalBullet;
    [SerializeField] private Bullet explosionBullet;

    private IShootStrategy m_CurrShootStrategy;

    private IShootStrategy m_NormalShootStrategy;
    private IShootStrategy m_ExplosionShootStrategy;

    private int m_Damage = 1;
    public int Damage => m_Damage;

    private float m_PowerRatio = 1f;
    public float PowerRatio => m_PowerRatio;

    private float m_BulletSpeed = 60f;
    public float BulletSpeed => m_BulletSpeed;

    private int m_BulletCount = 1;
    public int BulletCount => m_BulletCount;

    private int m_BulletThroughCount = 1;
    public int BulletThroughCount => m_BulletThroughCount;

    private float m_BulletExplosionPowerRatio = 1f;
    public float BulletExplosionPowerRatio => m_BulletExplosionPowerRatio;

    public static RailGun Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
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
        if (Player.PlayerInstance.Health.IsDead) return;

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

    public void SetShootStrategy(bool isExplosion)
    {
        m_CurrShootStrategy = isExplosion ? m_ExplosionShootStrategy : m_NormalShootStrategy;
    }

    public void AddBulletThroughCount(int value)
    {
        m_BulletThroughCount += value;
    }

    public void AddBulletExplosionPowerRatio(float value)
    {
        m_BulletExplosionPowerRatio += value * 0.01f;
    }
}
