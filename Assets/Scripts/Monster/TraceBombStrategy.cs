using UnityEngine;

public class TraceBombStrategy : ITraceStrategy
{
    public void Trace(Transform enemyTransform, Transform playerTransform, float speed)
    {
        Vector3 direction = (playerTransform.position - enemyTransform.position).normalized;
        direction.y = 0;
        enemyTransform.position += direction * speed * 2f * Time.deltaTime;

        if (Vector3.Distance(enemyTransform.position, playerTransform.position) < 1.5f)
        {
            Debug.Log("Boom!");
            GameObject.Destroy(enemyTransform.gameObject);
        }
    }
}
