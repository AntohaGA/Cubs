using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Cube[] cubes)
    {
        const string �olorProperty = "_Color";

        Color newColor;

        foreach (Cube cube in cubes)
        {
            newColor = Random.ColorHSV();
            cube.GetRenderer().material.SetColor(�olorProperty, newColor);
        }
    }
}
