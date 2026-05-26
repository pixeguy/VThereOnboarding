using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool
{
    private List<PoolObject> m_ActiveObjects = new();
    private Queue<PoolObject> m_InactiveObjects = new();

    [SerializeField]
    private string m_PoolName;
    public string PoolName => m_PoolName;

    [SerializeField]
    private PoolObject m_CachedObject;

    [SerializeField]
    private int m_InitialPoolSize;

    [SerializeField]
    private int m_IncrementSize;

    public void Initialise()
    {
        for (int i = 0; i < m_InitialPoolSize; i++)
        {
            GameObject Obj = GameObject.Instantiate(m_CachedObject.gameObject);
            Obj.SetActive(false);

            PoolObject PoolObj = Obj.GetComponent<PoolObject>();
            m_InactiveObjects.Enqueue(PoolObj);

            SampleObjectScript ObjScript = Obj.GetComponent<SampleObjectScript>();
            ObjScript.SetObjectPoolName(m_PoolName);
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
            if (m_IncrementSize != 0)
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
        if (m_ActiveObjects.Count == 0)
            return;

        PoolObject PoolObj = m_ActiveObjects[0];
        ReturnPoolObject(PoolObj);
    }

    public void ReturnPoolObject(PoolObject PoolObj)
    {
        m_ActiveObjects.Remove(PoolObj);
        PoolObj.OnObjectInactive();
        m_InactiveObjects.Enqueue(PoolObj);
    }
}
