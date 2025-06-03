using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    void OnDestroy()
    {
        Instantiate(ExplosionSingletone.Instance.GetExplosion(), transform.position, transform.rotation);
    }
}
