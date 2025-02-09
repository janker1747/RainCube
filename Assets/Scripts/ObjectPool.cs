using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _initialSize = 10;

    private Queue<Cube> _pool = new Queue<Cube>();
    private Color _defaultColor;

    private void Awake()
    {
        _defaultColor = Color.white;

        for (int i = 0; i < _initialSize; i++)
        {
            Cube cube = Instantiate(_prefab);
            cube.gameObject.SetActive(false);
            _pool.Enqueue(cube);

            cube.Changed += OnCubeChanged;
        }
    }

    public Cube GetObject(Vector3 position, Quaternion rotation)
    {
        Cube cube;

        Vector3 centerPosition = new Vector3(0f, 0f, 0f);
<<<<<<< HEAD
        float spawnRadius = 5f;
=======
        float spawnRadius = 5f;  
>>>>>>> 3573cce29437a2b68035ffc718aaf1614d52443e
        float minValue = 10f;
        float maxValue = 15f;

        float randomX = UnityEngine.Random.Range(centerPosition.x - spawnRadius, centerPosition.x + spawnRadius);
        float randomZ = UnityEngine.Random.Range(centerPosition.z - spawnRadius, centerPosition.z + spawnRadius);
<<<<<<< HEAD
        float randomY = UnityEngine.Random.Range(minValue, maxValue);
=======
        float randomY = UnityEngine.Random.Range(minValue, maxValue);  
>>>>>>> 3573cce29437a2b68035ffc718aaf1614d52443e

        position = new Vector3(randomX, randomY, randomZ);

        if (_pool.Count > 0)
        {
            cube = _pool.Dequeue();
            cube.gameObject.SetActive(true);
        }
        else
        {
            cube = Instantiate(_prefab);
        }

        cube.transform.SetPositionAndRotation(position, rotation);
        cube.SetColor(_defaultColor);

        return cube;
    }

    private void OnCubeChanged(Cube cube)
    {
        float minTime = 2f;
        float maxTime = 6f;

        float delay = UnityEngine.Random.Range(minTime, maxTime);

        ReturnObjectWithDelay(cube, delay);  
    }

    public void ReturnObjectWithDelay(Cube cube, float delay)
    {
        StartCoroutine(ReturnToPoolAfterDelay(cube, delay));
        cube.Changed -= OnCubeChanged;
    }

    private IEnumerator ReturnToPoolAfterDelay(Cube cube, float delay)
    {
        yield return new WaitForSeconds(delay);
        ReturnObject(cube);
    }

    public void ReturnObject(Cube cube)
    {
        cube.gameObject.SetActive(false);
        _pool.Enqueue(cube);
    }
}
