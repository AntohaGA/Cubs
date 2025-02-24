using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private CreatorCube _cubePrefab;

    Vector3 PositionNewCubes = new(0, 2, 0);

    private void Awake()
    {
        const int StartCountCubes = 5;

        CreatorCube _newCube;

        for(int i =0; i < StartCountCubes; i++)
        {
            _newCube = Instantiate(_cubePrefab, PositionNewCubes, Quaternion.identity);

            if (_newCube.TryGetComponent(out ClickerOnCube component))
            {
                component.OnClicked += AddCubesByChance;
            }
        }
    }

    public void AddCubesByChance(CreatorCube creatorCube)
    {
        const int MinNewCubs = 2;
        const int MaxNewCubs = 6;
        const int DecrimentorScale = 2;
        const int DecrimentorChance = 2;

        int CountNewCubes;

        CreatorCube _newCube;

        Vector3 PositionNewCubes = new (0, 2, 0);

        if (creatorCube.GetComponent<CounterChanceToDivide>().IsMakeCubes())
        {
            CountNewCubes = Random.Range(MinNewCubs, MaxNewCubs);

            for (int i = 0; i < CountNewCubes; i++)
            {
                _newCube = Instantiate(creatorCube, creatorCube.transform.position, creatorCube.transform.rotation);
                _newCube.GetComponent<ClickerOnCube>().OnClicked += AddCubesByChance;
                _newCube.GetComponent<CounterChanceToDivide>().Chance = creatorCube.GetComponent<CounterChanceToDivide>().Chance/ DecrimentorChance;
                _newCube.transform.localScale /= DecrimentorScale;
                _newCube.GetComponent<ColorChanger>().ChangeToRandomColor();
            }
        }

        creatorCube.GetComponent<Destroyer>().Explode();
    }
}