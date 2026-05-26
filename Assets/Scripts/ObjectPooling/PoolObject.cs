using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private string m_ObjectPoolName;

    public void SetObjectPoolName(string PoolName)
    {
        m_ObjectPoolName = PoolName;
    }

    public void ReturnSelfToPool()
    {
        ObjectPoolingController.Instance.ReturnObjectToPool(this, m_ObjectPoolName);
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
