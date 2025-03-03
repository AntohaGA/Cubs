using UnityEngine;

[RequireComponent(typeof(ClickerOnCubes))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionRadius;
    [SerializeField] private int _explosionForce;

    private ClickerOnCubes _clicker;

    private void Awake()
    {
        _clicker = GetComponent<ClickerOnCubes>();
        _clicker.ClickOnCube += Destroy;
    }

    private void OnDestroy()
    {
        _clicker.ClickOnCube -= Destroy;
    }

    public void Destroy(Cube cube)
    {
        cube.Destroy();
    }

    public void Explode(Cube[] cubes, Cube explodeCube)
    {
        foreach (Cube cube in cubes)
        {
            if (cube.TryGetComponent(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, explodeCube.transform.position, _explosionRadius);
            }
        }
    }
}