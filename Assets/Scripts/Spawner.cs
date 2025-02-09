using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private Transform _spawnPoint;
    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = FindObjectOfType<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.OnSpawnPressed += SpawnCube;
    }

    private void OnDisable()
    {
        _inputReader.OnSpawnPressed -= SpawnCube;
    }

    private void SpawnCube()
    {
        _pool.GetObject(_spawnPoint.position, Quaternion.identity);
    }
}
