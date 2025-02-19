using UnityEngine;

public class InitializatiorCubs : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    public void AddCubesByChance(int scaleDecrimenter, float chance)
    {
        const int _minNewCubs = 2;
        const int _maxNewCubs = 6;
        const int decrementorChance = 2;
        const int decrementorScale = 2;

        int _countNewCubes;

        Transform _TransformNewCube;

        Vector3 PositionNewCubes = new Vector3(0, 5, 0);

        GameObject newCube;

        if (IsMakeCubes(chance))
        {
            _TransformNewCube = new GameObject().transform;
            _TransformNewCube.localScale /= scaleDecrimenter;
            _TransformNewCube.position = PositionNewCubes;

            _countNewCubes = Random.Range(_minNewCubs, _maxNewCubs);

            for (int i = 0; i < _countNewCubes; i++)
            {
                newCube = Instantiate(_cubePrefab, _TransformNewCube);
                newCube.GetComponent<Destroyer>().ChanñeInitialization = chance / decrementorChance;
                newCube.GetComponent<Destroyer>().DecrimenterScale = scaleDecrimenter * decrementorScale;
                newCube.GetComponent<Renderer>().material.SetColor("_Color", Random.ColorHSV());
            }
        }
    }

    private bool IsMakeCubes(float chance)
    {
        const int minProcent = 0;
        const int maxProcent = 99;

        if (Random.Range(minProcent, maxProcent) < chance)
        {
            return true;
        }
        return false;
    }
}