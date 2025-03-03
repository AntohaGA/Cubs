using System;
using UnityEngine;

public class ClickerOnCubes : MonoBehaviour
{
    public event Action<Cube> ClickOnCube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.rigidbody != null)
                {
                    if (hit.rigidbody.TryGetComponent(out Cube cube))
                    {
                        ClickOnCube?.Invoke(cube);
                    }
                }
            }
        }
    }
}