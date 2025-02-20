using UnityEngine;

public class CounterChanceToDivide : MonoBehaviour
{
    public float Chance { get; set; }

    private void Awake()
    {
        Chance = 100;
    }

    public bool IsMakeCubes()
    {
        const int minProcent = 0;
        const int maxProcent = 99;

        if (Random.Range(minProcent, maxProcent) < Chance)
        {
            return true;
        }
        return false;
    }
}