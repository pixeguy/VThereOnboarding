using UnityEngine;

public class SampleObjectScript : MonoBehaviour
{
    private PoolObject m_PoolObject;

    private void Start()
    {
        m_PoolObject = GetComponent<PoolObject>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_PoolObject.ReturnSelfToPool();
        }
    }
}
