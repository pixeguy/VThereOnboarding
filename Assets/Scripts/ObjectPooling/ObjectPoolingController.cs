using System.Collections.Generic;
using Tomo.Core;
using UnityEngine;

[System.Serializable]
public struct ObjectPoolData
{
    public string PoolName;
    public PoolObject ObjectPrefab;
    public bool AllowPoolExpansion;
    public bool InitialPoolSize;
    public bool IncrementSize;
}

public class ObjectPoolingController : ControllerBase<ObjectPoolingController>
{
    private Dictionary<string, ObjectPool> m_ObjectPools = new();

    public PoolObject Object1;
    public PoolObject Object2;

    protected override void ControllerAwake()
    {
        AddNewPool("Pool1", Object1);
        AddNewPool("Pool2", Object2);
        SetControllerToReady();
    }

    public void AddNewPool(string PoolName, PoolObject Obj)
    {
        //ObjectPool Pool = new ObjectPool(Obj);
        //RegisterPool(PoolName, Pool);
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
