using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private void Awake()
    {
        const int StartCountCubes = 5;

        Cube startCube;

        Vector3 positionNewCubes = new(0, 2, 0);

        for (int i =0; i < StartCountCubes; i++)
        {
            startCube = Instantiate(_cubePrefab, positionNewCubes, Quaternion.identity);

            if (startCube.TryGetComponent(out ClickerOnCube component))
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

        int countNewCubes;

        Cube newCube;

        if (clickCube.IsDivide())
        {
            countNewCubes = Random.Range(MinNewCubs, MaxNewCubs);

            for (int i = 0; i < countNewCubes; i++)
            {               
                newCube = Instantiate(clickCube);
                newCube.GetComponent<ClickerOnCube>().OnClicked += AddCubesByChance;
                newCube.transform.localScale /= DecrimentorScale;
                newCube.ChangeColor();
                newCube.SetNewChanceDivide(clickCube.Chance);
                newCube.Explode();
            }
        }

        clickCube.Destroy();
    }
}