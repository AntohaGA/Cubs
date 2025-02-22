using System;
using UnityEngine;

public class ClickerOnCube : MonoBehaviour
{
    public event Action OnClicked;

    private void OnMouseDown()
    {
        OnClicked?.Invoke();
    }
}
