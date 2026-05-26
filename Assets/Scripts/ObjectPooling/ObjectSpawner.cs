using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ObjectPool Pool = ObjectPoolingController.Instance.TryGetPool("Pool1");
            if (Pool != null)
            {
                PoolObject Obj = Pool.GetPoolObject();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ObjectPool Pool = ObjectPoolingController.Instance.TryGetPool("Pool2");
            if (Pool != null)
            {
                PoolObject Obj = Pool.GetPoolObject();
            }
        }
    }
}
