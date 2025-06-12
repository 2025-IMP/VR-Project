using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    private int m_ExplosionDamage = 1;

    void OnDestroy()
    {
        Explode();
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy") && collider.TryGetComponent(out EnemyController enemy))
            {
                enemy.TakeDamage(m_ExplosionDamage);
            }
        }

        Instantiate(ExplosionSingletone.Instance.GetExplosion(), transform.position, transform.rotation);
    }
}
