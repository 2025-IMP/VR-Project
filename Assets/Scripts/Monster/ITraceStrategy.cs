using UnityEngine;

public interface ITraceStrategy
{
    void Trace(Transform enemyTransform, Transform playerTransform, float speed);
}