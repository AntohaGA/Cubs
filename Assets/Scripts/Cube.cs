using UnityEngine;

public class Cube : MonoBehaviour
{
    public float Chance { get; private set; }
    public float ExplodeForse { get; private set; }

    private void Awake()
    {
        Chance = 100;
        ExplodeForse = 500;
    }

    public bool CanDivide()
    {
        const int MinProcent = 0;
        const int MaxProcent = 98;

        return (Random.Range(MinProcent, MaxProcent + 1) < Chance);
    }

    public Renderer GetRenderer()
    {
        return GetComponent<Renderer>();
    }

    public void Init(float oldChance, float oldExplodeForse)
    {
        const int DecrimentorChance = 2;
        const int DecrimentorScale = 2;

        const float IncrementForse = 1.2f;

        Chance = oldChance / DecrimentorChance;
        transform.localScale /= DecrimentorScale;
        ExplodeForse *= IncrementForse;
    }
}