using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public EnemyType Type;
    public EnemyController Prefab;
}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyData[] m_EnemyStorage;
    [SerializeField] private Transform m_EnemyRoot;

    [SerializeField] private Transform m_SpawnPointRoot;
    private EnemySpawnPoint[] m_SpawnPoints;
    public EnemySpawnPoint[] AvailableSpawnPoints
    {
        get
        {
            return m_SpawnPoints.Where(spawnPoint => spawnPoint.CanSpawn()).ToArray();
        }
    }

    private Dictionary<EnemyType, EnemyController> m_EnemyDatas = new Dictionary<EnemyType, EnemyController>();

    private void Awake()
    {
        foreach (EnemyData data in m_EnemyStorage)
        {
            m_EnemyDatas[data.Type] = data.Prefab;
        }
        m_SpawnPoints = m_SpawnPointRoot.GetComponentsInChildren<EnemySpawnPoint>();
    }

    public void Spawn(EnemyType type, Vector3 position)
    {
        EnemyController prefab = m_EnemyDatas[type];
        //Instantiate(prefab, position, Quaternion.identity, m_EnemyRoot);
    }
    public void Spawn(EnemyType type)
    {
        EnemyController prefab = m_EnemyDatas[type];
        EnemySpawnPoint[] spawnPoints = AvailableSpawnPoints;
        int index = Random.Range(0, spawnPoints.Length);

        //Instantiate(prefab, spawnPoints[index].transform.position, Quaternion.identity, m_EnemyRoot);
    }
}
