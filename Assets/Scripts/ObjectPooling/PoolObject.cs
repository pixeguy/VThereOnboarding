using UnityEngine;

public class PoolObject : MonoBehaviour
{
    public void OnObjectActive()
    {
        gameObject.SetActive(true);
    }

    public void OnObjectInactive()
    {
        gameObject.SetActive(false);
    }
}
