using UnityEngine;

public class SampleObjectScript : MonoBehaviour
{
    [HideInInspector]
    public string ObjectPoolName;
    private PoolObject m_PoolObject;
    private ObjectPool m_Pool;

    private Rigidbody m_RigidBody;

    private void Start()
    {
        m_Pool = ObjectPoolingController.Instance.TryGetPool(ObjectPoolName);
        m_PoolObject = GetComponent<PoolObject>();
        m_RigidBody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
        m_RigidBody.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        m_Pool.ReturnPoolObject(m_PoolObject);
        }
    }
}
