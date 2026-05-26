using System.Collections.Generic;
using Tomo.Core;
using UnityEngine;

[System.Serializable]
public struct ObjectPoolData
{
    public string PoolName;
    public PoolObject ObjectPrefab;
    public bool AllowPoolExpansion;
    public int InitialPoolSize;

    [Header("Not needed if AllowPoolExpansion is false")]
    public int IncrementSize;
}

public class ObjectPoolingController : ControllerBase<ObjectPoolingController>
{
    private Dictionary<string, ObjectPool> m_ObjectPools = new();

    [SerializeField] private ObjectPoolData[] m_PoolData;

    protected override void ControllerAwake()
    {
        foreach(ObjectPoolData PoolData in m_PoolData)
        {
            ObjectPool Pool = new ObjectPool(PoolData);
            RegisterPool(PoolData.PoolName, Pool);
        }
        SetControllerToReady();
    }

    public void RegisterPool(string PoolName, ObjectPool Pool)
    {
        m_ObjectPools.Add(PoolName, Pool);
    }

    public void RemovePool(string PoolName)
    {
        m_ObjectPools.Remove(PoolName);
    }

    public ObjectPool TryGetPool(string PoolName)
    {
        m_ObjectPools.TryGetValue(PoolName, out ObjectPool Pool);
        if (Pool == null)
            return null;
        else
            return Pool;
    }
}
