using UnityEngine;

[RequireComponent(typeof(ClickerOnCubes))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
public class CubeDivider : MonoBehaviour
{
    private ClickerOnCubes _clickerOnCubes;
    private CubeSpawner _cubeSpawner;
    private Exploder _exploder;
    private ColorChanger _colorChanger;

    private void Awake()
    {
        _clickerOnCubes = GetComponent<ClickerOnCubes>();
        _cubeSpawner = GetComponent<CubeSpawner>();
        _exploder = GetComponent<Exploder>();
        _colorChanger = GetComponent<ColorChanger>();

        _clickerOnCubes.CubeCliked += Divide;
    }

    private void OnDestroy()
    {
        _clickerOnCubes.CubeCliked -= Divide;
    }

    private void Divide(Cube cube)
    {
        Cube[] cubes;

        if (cube.CanDivide())
        {
            cubes = _cubeSpawner.MakeNewCubes(cube);
            _colorChanger.ChangeColor(cubes);

            foreach (Cube newCube in cubes)
            {
                newCube.Init(cube.Chance, cube.ExplodeForse);
            }
        }
        else
        {
            _exploder.Explode(cube);
        }

        Destroy(cube.gameObject);
    }
}