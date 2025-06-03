using UnityEngine;

public interface IShootStrategy
{
    public void Shoot(Transform shootTransform, int damage, float speed);
}
