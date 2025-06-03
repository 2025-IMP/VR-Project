using TheDeveloperTrain.SciFiGuns;
using UnityEngine;

public class NormalShootStrategy : IShootStrategy
{
    private GameObject m_Bullet;

    public NormalShootStrategy(GameObject bullet)
    {
        m_Bullet = bullet;
    }

    public void Shoot(Transform shootTransform, int damage, float speed, int bulletCount)
    {
        for (int i = 0; i < bulletCount; i++)
        {

        }
        GameObject gBullet = GameObject.Instantiate(m_Bullet, shootTransform.position, shootTransform.rotation);
        Bullet bullet = gBullet.GetComponent<Bullet>();
        bullet.Setup(damage, speed);
    }
}
