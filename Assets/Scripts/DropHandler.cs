using IMP.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DropData
{
    public DropType Type;
    public DropItem Prefab;
}

public class DropHandler : MonoBehaviour
{
    [SerializeField] private DropData[] m_DropStorage;
    private Dictionary<DropType, DropItem> m_DropDatas = new Dictionary<DropType, DropItem>();

    [SerializeField] private Transform m_DropRoot;

    public static Action<Transform> OnEnemyDead;

    private void Awake()
    {
        foreach (DropData data in m_DropStorage)
        {
            m_DropDatas[data.Type] = data.Prefab;
        }
    }

    private void OnEnable()
    {
        OnEnemyDead += SpawnDropItem;
    }

    private void OnDisable()
    {
        OnEnemyDead -= SpawnDropItem;
    }

    private void SpawnDropItem(Transform tr)
    {
        Instantiate(m_DropDatas[DropType.EXP], tr.position, Quaternion.identity, m_DropRoot);
    }
}
