using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private MeshRenderer _renderer;
    public event Action<Cube> Changed;

    public MeshRenderer Renderer => _renderer;
    private bool _hasCollided = false;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
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
        Changed?.Invoke(this);
    }
}

