using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeToRandomColor()
    {
        if(TryGetComponent(out Renderer renderer))
        {
            renderer.material.SetColor("_Color", Random.ColorHSV());
        }
    }
}