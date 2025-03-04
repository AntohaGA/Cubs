using UnityEngine;

[RequireComponent(typeof(ClickerOnCubes))]
[RequireComponent(typeof(CubeSpawner))]
[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(ColorChanger))]
public class CubesController : MonoBehaviour
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

        _clickerOnCubes.ClickOnCube += Divide;
    }

    private void OnDestroy()
    {
        _clickerOnCubes.ClickOnCube -= Divide;
    }

    private void Divide(Cube cube)
    {
        Cube[] cubes;

        cubes = _cubeSpawner.DivideCube(cube);

        if(cubes != null)
        {
            _colorChanger.ChangeColor(cubes);

            foreach (Cube newCube in cubes)
            {
                newCube.SetNewChance(cube.Chance);
                newCube.SetNewScale();
            }

            _exploder.Explode(cubes, cube);
        }

        Destroy(cube);
    }
}