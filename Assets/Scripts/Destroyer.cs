using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private void OnMouseUpAsButton()
    {
        GetComponent<SpawnerCubs>().AddCubesByChance();
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (GameObject cube in GameObject.FindGameObjectsWithTag("Cub"))
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }
}