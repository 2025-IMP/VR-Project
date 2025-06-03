using System.Collections;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Player m_Player;
    private EnemySpawner m_Spawner;

    private void Awake()
    {
        m_Player = FindAnyObjectByType<Player>();
        m_Spawner = FindAnyObjectByType<EnemySpawner>();
    }

    private void Start()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    public IEnumerator EnemySpawnCoroutine()
    {
        int spawnCount = 5;

        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                m_Spawner.Spawn(EnemyType.Normal);
                yield return null;
            }

            yield return new WaitForSeconds(3f);
        }
    }
}
