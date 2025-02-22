using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void ChangeToRandomColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
    }
}