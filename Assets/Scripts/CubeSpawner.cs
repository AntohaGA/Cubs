using UnityEngine;

[RequireComponent (typeof(ClickerOnCube))]
public class CubeSpawner : MonoBehaviour
{
    private ClickerOnCube _clickerOnCube;

    private void Awake()
    {
        _clickerOnCube = GetComponent<ClickerOnCube>();
        _clickerOnCube.OnClicked += AddCubesByChance;
    }

    private void OnDisable()
    {
        _clickerOnCube.OnClicked -= AddCubesByChance;
    }

    public void AddCubesByChance()
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;
        const int DecrimentorScale = 2;
        const int DecrimentorChance = 2;

        int CountNewCubes;

        Vector3 PositionNewCubes = new (0, 3, 0);

        GameObject newCube;

        if (GetComponent<CounterChanceToDivide>().IsMakeCubes())
        {
            CountNewCubes = Random.Range(MinNewCubs, MaxNewCubs);

            for (int i = 0; i < CountNewCubes; i++)
            {
                newCube = Instantiate(gameObject, PositionNewCubes, Quaternion.identity);
                newCube.GetComponent<CounterChanceToDivide>().Chance = GetComponent<CounterChanceToDivide>().Chance / DecrimentorChance;
                newCube.transform.localScale = transform.localScale / DecrimentorScale;
                newCube.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
            }
        }

        GetComponent<Destroyer>().Explode();
    }
}