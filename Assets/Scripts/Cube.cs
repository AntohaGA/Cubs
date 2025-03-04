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

        if (Random.Range(MinProcent, MaxProcent) < Chance)
        {
            return true;
        }

        return false;
    }

    public void SetNewChance(float oldChance)
    {
        const int DecrimentorChance = 2;

        Chance = oldChance / DecrimentorChance;
    }

    public void SetNewScale()
    {
        const int DecrimentorScale = 2;

        transform.localScale /= DecrimentorScale;
    }
}