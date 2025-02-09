using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer _renderer;
    private ObjectPool _pool;
    public event Action<Cube> Changer;

    public MeshRenderer Renderer => _renderer;
    private bool _hasCollided = false; 

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        _pool = FindObjectOfType<ObjectPool>();
    }
    public void SetColor(Color color)
    {
        _renderer.material.color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided) 
        {
            return;
        }

        _hasCollided = true;
        Changer?.Invoke(this);
        ReturnToPool();
    }

    private void ReturnToPool()
    {
        float minTime = 2f;
        float maxTime = 6f;
        float delay = UnityEngine.Random.Range(minTime, maxTime);

        _pool.ReturnObjectWithDelay(this, delay);  
    }
}
