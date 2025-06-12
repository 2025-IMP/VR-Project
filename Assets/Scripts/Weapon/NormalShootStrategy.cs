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
        for (int i = 0; i < bulletCount; i++)
        {

        }
        Bullet bullet = GameObject.Instantiate(m_Bullet, shootTransform.position, shootTransform.rotation);
        bullet.Setup(damage, speed);
    }
}
