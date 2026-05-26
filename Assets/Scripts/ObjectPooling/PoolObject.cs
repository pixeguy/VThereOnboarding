using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public virtual void OnObjectActive()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnObjectInactive()
    {
        gameObject.SetActive(false);
    }
}
