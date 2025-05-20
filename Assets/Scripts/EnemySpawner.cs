using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 2f;
    public Vector2 half = new Vector2(9f, 9f);   // 맵 반경

    void Start() { InvokeRepeating(nameof(Spawn), 1f, interval); }

    void Spawn()
    {
        Vector3 p;
        p.x = Random.Range(-half.x, half.x);
        p.z = Random.Range(-half.y, half.y);
        p.y = 0.3f;
        Instantiate(prefab, p, Quaternion.identity);
    }
}
