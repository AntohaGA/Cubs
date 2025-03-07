using System;
using UnityEngine;

public class ClickerOnCubes : MonoBehaviour
{
    public event Action<Cube> CubeCliked;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.rigidbody.TryGetComponent(out Cube cube))
                {
                    CubeCliked?.Invoke(cube);
                }
            }
        }
    }
}