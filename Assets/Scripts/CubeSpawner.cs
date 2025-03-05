using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private void Awake()
    {
        const int StartCountCubes = 5;

        CreateStartCubes(StartCountCubes);
    }

    public Cube[] MakeNewCubes(Cube cube)
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;

        int countNewCubes;

        Cube[] newCubes;

        countNewCubes = Random.Range(MinNewCubs, MaxNewCubs);
        newCubes = new Cube[countNewCubes];

        for (int i = 0; i < countNewCubes; i++)
        {
            newCubes[i] = CreateCube(cube);
        }

        return newCubes;
    }

    private void CreateStartCubes(int count)
    {
        Vector3 positionNewCubes = new(0, 2, 0);

        for (int i = 0; i < count; i++)
        {
            CreateCube(_cubePrefab, positionNewCubes, Quaternion.identity);
        }
    }

    private Cube CreateCube(Cube cube)
    {
        return Instantiate(cube);
    }

    private Cube CreateCube(Cube cube, Vector3 position, Quaternion rotation)
    {
        return Instantiate(cube, position, rotation);
    }
}