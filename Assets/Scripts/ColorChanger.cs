using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeColor(Cube[] cubes)
    {
        foreach (Cube cube in cubes)
        {
            cube.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
        }
    }
}
