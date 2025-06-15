using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class NormalShootStrategy : IShootStrategy
{
    private Bullet m_Bullet;

    public NormalShootStrategy(Bullet bullet)
    {
        m_Bullet = bullet;
    }

    public void Shoot(Transform shootTransform, int damage, float speed, int bulletCount)
    {
        AudioManager.Instance.PlayAudio(AudioType.SFX, AudioManager.Instance.gunShootSFX);

        for (int i = 0; i < RailGun.Instance.BulletCount; i++)
        {
            Bullet bullet = GameObject.Instantiate(m_Bullet, shootTransform.position, shootTransform.rotation);
            bullet.Setup(damage, speed);
        }
    }
}
