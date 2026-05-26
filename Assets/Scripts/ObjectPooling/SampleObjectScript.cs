using UnityEngine;

public class SampleObjectScript : MonoBehaviour
{
    private string m_ObjectPoolName;
    private PoolObject m_PoolObject;
    private ObjectPool m_Pool;

    private void Start()
    {
        m_Pool = ObjectPoolingController.Instance.TryGetPool(m_ObjectPoolName);
        m_PoolObject = GetComponent<PoolObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Pool.ReturnPoolObject(m_PoolObject);
        }
    }

    public void SetObjectPoolName(string PoolName)
    {
        m_ObjectPoolName = PoolName;
    }
}
