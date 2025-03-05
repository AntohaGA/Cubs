using UnityEngine;

public class Cube : MonoBehaviour
{
    public float Chance { get; private set; }

    private void Awake()
    {
        Chance = 100;
    }

    public bool CanDivide()
    {
        const int MinProcent = 0;
        const int MaxProcent = 99;

        return (Random.Range(MinProcent, MaxProcent) < Chance);
    }

    public void Init(float oldChance)
    {
        const int DecrimentorChance = 2;
        const int DecrimentorScale = 2;

        Chance = oldChance / DecrimentorChance;
        transform.localScale /= DecrimentorScale;
    }
}