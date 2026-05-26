using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private List<PoolObject> m_ActiveObjects = new();
    private Queue<PoolObject> m_InactiveObjects = new();

    private PoolObject m_CachedObject;

    private bool m_AllowPoolExpansion = true;
    private int m_InitialPoolSize;
    private int m_IncrementSize;

    public ObjectPool(ObjectPoolData PoolData)
    {
        m_CachedObject = PoolData.ObjectPrefab;
        m_AllowPoolExpansion = PoolData.AllowPoolExpansion;
        m_InitialPoolSize = PoolData.InitialPoolSize;
        m_IncrementSize = PoolData.IncrementSize;

        for (int i = 0; i < m_InitialPoolSize; i++)
        {
            GameObject Obj = GameObject.Instantiate(m_CachedObject.gameObject);
            Obj.SetActive(false);

            PoolObject PoolObj = Obj.GetComponent<PoolObject>();
            m_InactiveObjects.Enqueue(PoolObj);

            SampleObjectScript ObjScript = Obj.GetComponent<SampleObjectScript>();
            ObjScript.SetObjectPoolName(PoolData.PoolName);
        }
    }

    public void AddNewObjectsToPool()
    {
        for (int i = 0; i < m_IncrementSize; i++)
        {
            GameObject Obj = GameObject.Instantiate(m_CachedObject.gameObject);
            Obj.SetActive(false);

            PoolObject PoolObj = Obj.GetComponent<PoolObject>();
            m_InactiveObjects.Enqueue(PoolObj);
        }
    }

    public PoolObject GetPoolObject()
    {
        if (m_InactiveObjects.Count <= 0)
        {
            if (m_AllowPoolExpansion)
                AddNewObjectsToPool();
            else 
                ReturnEarliestObject();
        }

        if (m_InactiveObjects.TryDequeue(out PoolObject poolObj))
        {
            m_ActiveObjects.Add(poolObj);
            poolObj.OnObjectActive();
            return poolObj;
        }

        return null;
    }

    public void ReturnEarliestObject()
    {
        if (m_ActiveObjects.Count > 0)
        {
            PoolObject PoolObj = m_ActiveObjects[0];
            ReturnPoolObject(PoolObj);
        }
    }

    public void ReturnPoolObject(PoolObject PoolObj)
    {
        m_ActiveObjects.Remove(PoolObj);
        PoolObj.OnObjectInactive();
        m_InactiveObjects.Enqueue(PoolObj);
    }
}
