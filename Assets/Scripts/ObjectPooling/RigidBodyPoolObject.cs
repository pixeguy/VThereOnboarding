using UnityEngine;

public class RigidBodyPoolObject : PoolObject
{
    private Rigidbody m_RigidBody;

    private void Awake()
    {
        m_RigidBody = GetComponent<Rigidbody>();
    }

    public override void HandleReturnToPool()
    {
        m_RigidBody.linearVelocity = Vector3.zero;
        m_RigidBody.angularVelocity = Vector3.zero;
        transform.position = Vector3.zero;

        base.HandleReturnToPool();
    }
}
