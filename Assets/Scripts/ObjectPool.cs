using System;
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
        }
    }

    public Cube GetObject(Vector3 position, Quaternion rotation)
    {
        Cube cube;

        Vector3 centerPosition = new Vector3(0f, 0f, 0f);
        float spawnRadius = 5f;  

        float randomX = UnityEngine.Random.Range(centerPosition.x - spawnRadius, centerPosition.x + spawnRadius);
        float randomZ = UnityEngine.Random.Range(centerPosition.z - spawnRadius, centerPosition.z + spawnRadius);
        float randomY = UnityEngine.Random.Range(10f, 15f);  

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

    public void ReturnObjectWithDelay(Cube cube, float delay)
    {
        StartCoroutine(ReturnToPoolAfterDelay(cube, delay));
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

