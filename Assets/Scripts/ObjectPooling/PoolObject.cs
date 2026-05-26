using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private string m_ObjectPoolName;
    private ObjectPool m_Pool;

    private void Start()
    {
        m_Pool = ObjectPoolingController.Instance.TryGetPool(m_ObjectPoolName);
    }

    public void SetObjectPoolName(string PoolName)
    {
        m_ObjectPoolName = PoolName;
    }

    public void ReturnSelfToPool()
    {
        m_Pool.ReturnPoolObject(this);
    }

    public virtual void HandleTakenFromPool()
    {
        gameObject.SetActive(true);
    }

    public virtual void HandleReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
