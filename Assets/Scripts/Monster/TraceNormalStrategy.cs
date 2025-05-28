using UnityEngine;

public class TraceNormalStrategy : ITraceStrategy
{
    public void Trace(Transform enemyTransform, Transform playerTransform, float speed)
    {
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
        direction.y = 0;
        enemyTransform.position += direction * speed * Time.deltaTime;
    }
}
