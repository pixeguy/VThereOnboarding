using UnityEngine;

public class PoolObject : MonoBehaviour
{
    private Rigidbody m_RigidBody;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    public void OnObjectActive()
    {
        gameObject.SetActive(true);
    }

    public void OnObjectInactive()
    {
        var m_RigidBody = GetComponent<Rigidbody>();
        m_RigidBody.linearVelocity = Vector3.zero;
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
