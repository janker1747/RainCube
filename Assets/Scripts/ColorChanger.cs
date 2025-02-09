using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnEnable()
    {
        _cube.Changer += ChangeColor;
    }

    private void OnDisable()
    {
        _cube.Changer -= ChangeColor;
    }

    public void ChangeColor(Cube cube)
    {
        MeshRenderer renderer = cube.Renderer;

        if (renderer != null)
        {
            renderer.material.color = Random.ColorHSV();
        }
    }
}