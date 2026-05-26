using System.Collections.Generic;
using Tomo.Core;
using UnityEngine;

public class ObjectPoolingController : ControllerBase<ObjectPoolingController>
{
    private Dictionary<string, ObjectPool> m_ObjectPools = new();

    [SerializeField] private ObjectPool[] m_Pool;

    protected override void ControllerAwake()
    {
        foreach (ObjectPool pool in m_Pool)
        {
            pool.Initialise();
            RegisterPool(pool.PoolName, pool);
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
