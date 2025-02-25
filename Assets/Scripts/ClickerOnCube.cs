using System;
using UnityEngine;

public class ClickerOnCube : MonoBehaviour
{
    public event Action<Cube> OnClicked;

    private void OnMouseDown()
    {
        if(TryGetComponent(out Cube component))
        {
            OnClicked?.Invoke(component);
        }
    }
}