using UnityEngine;

[RequireComponent(typeof(ClickerOnCubes))]
[RequireComponent(typeof(Exploder))]
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private ClickerOnCubes _clicker;
    private Exploder _exploder;

    private void Awake()
    {
        const int StartCountCubes = 5;

        Cube startCube;

        Vector3 positionNewCubes = new(0, 2, 0);

        _clicker = GetComponent<ClickerOnCubes>();
        _clicker.ClickOnCube += AddCubesByChance;
        _exploder = GetComponent<Exploder>();

        for (int i = 0; i < StartCountCubes; i++)
        {
            startCube = Instantiate(_cubePrefab, positionNewCubes, Quaternion.identity);
        }
    }

    private void OnDestroy()
    {
        _clicker.ClickOnCube -= AddCubesByChance;
    }

    public void AddCubesByChance(Cube cube)
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;

        int countNewCubes;

        Cube[] newCubes;

        if (cube.IsDivide())
        {
            countNewCubes = Random.Range(MinNewCubs, MaxNewCubs);
            newCubes = new Cube[countNewCubes];

            for (int i = 0; i < countNewCubes; i++)
            {
                newCubes[i] = Instantiate(cube);
                newCubes[i].SetNewParameters(cube.Chance);
            }

            _exploder.Explode(newCubes, cube);
        }
    }
}