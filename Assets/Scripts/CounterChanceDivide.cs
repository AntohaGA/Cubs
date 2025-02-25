using UnityEngine;

public class CounterChanceDivide : MonoBehaviour
{
    public float Chance { get; private  set; }

    private void Awake()
    {
        Chance = 100;
    }

    public void DecrimentChance(float oldChance)
    {
        const int Decrimentor = 2;

        Chance = oldChance / Decrimentor;
    }

    public bool IsMakeCubes()
    {
        const int MinProcent = 0;
        const int MaxProcent = 99;

        Debug.Log($"{Chance}");

        if (Random.Range(MinProcent, MaxProcent) < Chance)
        {
            return true;
        }

        return false;
    }
}