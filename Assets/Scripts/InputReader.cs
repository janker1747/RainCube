using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action OnSpawnPressed;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpawnPressed?.Invoke();
        }
    }
}
