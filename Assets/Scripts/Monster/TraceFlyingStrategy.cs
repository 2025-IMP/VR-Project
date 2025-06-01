using UnityEngine;

public class TraceFlyingStrategy : ITraceStrategy
{
    private float flightHeight = 2.5f;

    public void Trace(Transform enemyTransform, Transform playerTransform, float speed)
    {
        Vector3 targetPosition = playerTransform.position;
        targetPosition.y = flightHeight;

        Vector3 direction = (targetPosition - enemyTransform.position).normalized;
        enemyTransform.position += direction * speed * Time.deltaTime;

        Vector3 pos = enemyTransform.position;
        pos.y = flightHeight;
        enemyTransform.position = pos;
    }
}
