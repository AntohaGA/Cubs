using UnityEngine;

public class Cube : MonoBehaviour
{
    public float Chance { get; private set; }

    private void Awake()
    {
        Chance = 100;
    }

    public void ChangeColor()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
    }

    public bool IsDivide()
    {
        const int MinProcent = 0;
        const int MaxProcent = 99;

        if (Random.Range(MinProcent, MaxProcent) < Chance)
        {
            return true;
        }

        return false;
    }

    public void SetNewParameters(float oldChance)
    {
        const int DecrimentorScale = 2;
        const int DecrimentorChance = 2;

        Chance = oldChance / DecrimentorChance;
        transform.localScale /= DecrimentorScale;
        ChangeColor();
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}