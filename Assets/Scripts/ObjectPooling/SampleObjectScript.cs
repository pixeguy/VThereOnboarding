using UnityEngine;

public class SampleObjectScript : MonoBehaviour
{
    [HideInInspector]
    public string ObjectPoolName;
    private PoolObject m_PoolObject;
    private ObjectPool m_Pool;

    private void Start()
    {
        m_Pool = ObjectPoolingController.Instance.TryGetPool(ObjectPoolName);
        m_PoolObject = GetComponent<PoolObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_Pool.ReturnPoolObject(m_PoolObject);
        }
    }
}
