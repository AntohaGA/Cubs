using System;
using UnityEngine;

public class ClickerOnCube : MonoBehaviour
{
    public event Action<CreatorCube> OnClicked;

    private void OnMouseDown()
    {
        if(TryGetComponent(out CreatorCube component))
        {
            OnClicked?.Invoke(component);
        }
    }
}