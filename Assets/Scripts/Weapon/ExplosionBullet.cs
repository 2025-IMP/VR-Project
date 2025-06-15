using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    private int m_ExplosionDamage = 1;
    private int throughCount = 0;

    void OnDestroy()
    {
        Explode();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && other.TryGetComponent(out EnemyController enemy))
        {
            if (enemy.IsDead) return;

            enemy.TakeDamage((int)(RailGun.Instance.Damage * Player.PlayerInstance.PowerRatio * RailGun.Instance.PowerRatio));
            throughCount += 1;
            Explode();

            if (throughCount >= RailGun.Instance.BulletThroughCount)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage((int)(m_ExplosionDamage * Player.PlayerInstance.PowerRatio * RailGun.Instance.BulletExplosionPowerRatio));
            }
        }

        Instantiate(ExplosionSingletone.Instance.GetExplosion(), transform.position, transform.rotation);
    }
}
