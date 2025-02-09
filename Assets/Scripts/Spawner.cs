using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pool.GetObject(_spawnPoint.position, Quaternion.identity);
        }
    }
}
