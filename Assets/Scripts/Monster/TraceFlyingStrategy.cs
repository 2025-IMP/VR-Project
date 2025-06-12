using UnityEngine;

public class TraceFlyingStrategy : ITraceStrategy
{
    private float hoverHeight = 8f;

    public void Trace(Transform enemyTransform, Transform playerTransform, float speed)
    {
        Vector3 rayOrigin = enemyTransform.position + Vector3.up * 5f;
        Ray ray = new Ray(rayOrigin, Vector3.down);
        float terrainY = enemyTransform.position.y;

        int groundLayerMask = LayerMask.GetMask("Ground");

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayerMask))
        {
            terrainY = hit.point.y;
        }

        Vector3 targetPosition = new Vector3(
            playerTransform.position.x,
            terrainY + hoverHeight,
            playerTransform.position.z
        );

        Vector3 direction = (targetPosition - enemyTransform.position).normalized;
        direction.y = 0;
        enemyTransform.position += direction * speed * Time.deltaTime;

        Vector3 fixedPos = enemyTransform.position;
        fixedPos.y = terrainY + hoverHeight;
        enemyTransform.position = fixedPos;

        Vector3 lookDir = (playerTransform.position - enemyTransform.position);
        lookDir.y = 0;
        if (lookDir != Vector3.zero)
        {
            enemyTransform.rotation = Quaternion.Slerp(
                enemyTransform.rotation,
                Quaternion.LookRotation(lookDir),
                10f * Time.deltaTime
            );
        }

        Debug.DrawRay(rayOrigin, Vector3.down * 10f, Color.green);
    }
}
