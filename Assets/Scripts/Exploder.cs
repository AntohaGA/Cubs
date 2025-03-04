using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionRadius;
    [SerializeField] private int _explosionForce;

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