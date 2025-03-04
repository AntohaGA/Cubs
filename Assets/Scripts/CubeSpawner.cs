using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private void Awake()
    {
        const int StartCountCubes = 5;

        CreateStartCubes(StartCountCubes);
    }

    public Cube[] DivideCube(Cube cube)
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;

        int countNewCubes;

        Cube[] newCubes = null;

        if (cube.CanDivide())
        {
            countNewCubes = Random.Range(MinNewCubs, MaxNewCubs);
            newCubes = new Cube[countNewCubes];

            for (int i = 0; i < countNewCubes; i++)
            {
                newCubes[i] = Instantiate(cube);
            }
        }

        Destroy(cube.gameObject);

        return newCubes;
    }

    private void CreateStartCubes(int count)
    {
        Vector3 positionNewCubes = new(0, 2, 0);

        for (int i = 0; i < count; i++)
        {
            Instantiate(_cubePrefab, positionNewCubes, Quaternion.identity);
        }
    }
}