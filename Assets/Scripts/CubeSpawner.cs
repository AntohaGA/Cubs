using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    Vector3 PositionNewCubes = new(0, 2, 0);

    private void Awake()
    {
        const int StartCountCubes = 5;

        Cube cube;

        for(int i =0; i < StartCountCubes; i++)
        {
            cube = Instantiate(_cubePrefab, PositionNewCubes, Quaternion.identity);

            if (cube.TryGetComponent(out ClickerOnCube component))
            {
                component.OnClicked += AddCubesByChance;
            }
        }
    }

    public void AddCubesByChance(Cube clickCube)
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;
        const int DecrimentorScale = 2;

        float oldChance;

        int countNewCubes;

        Cube newCube;

        Vector3 positionNewCubes = new (0, 2, 0);

        if (clickCube.GetComponent<CounterChanceDivide>().IsMakeCubes())
        {
            countNewCubes = Random.Range(MinNewCubs, MaxNewCubs);

            for (int i = 0; i < countNewCubes; i++)
            {
                newCube = Instantiate(clickCube, clickCube.transform.position, clickCube.transform.rotation);
                newCube.GetComponent<ClickerOnCube>().OnClicked += AddCubesByChance;
                newCube.transform.localScale /= DecrimentorScale;
                newCube.GetComponent<ColorChanger>().ChangeToRandomColor();

                oldChance = clickCube.GetComponent<CounterChanceDivide>().Chance;
                newCube.GetComponent<CounterChanceDivide>().DecrimentChance(oldChance);
            }
        }

        clickCube.GetComponent<Destroyer>().Explode();
    }
}