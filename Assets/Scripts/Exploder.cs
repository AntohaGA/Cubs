using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FinderObjects))]
public class Exploder : MonoBehaviour
{
    [SerializeField] private int _explosionRadius;

    private FinderObjects _finderObjects;

    private void Awake()
    {
        _finderObjects = GetComponent<FinderObjects>();
    }

    public void Explode(Cube explodeCube)
    {
        List<Rigidbody> explodableObjects = new();

        explodableObjects = _finderObjects.FindExplodableObjectsInArea(explodeCube.transform.position, _explosionRadius);

        foreach (Rigidbody cube in explodableObjects)
        {
            cube.AddExplosionForce(explodeCube.ExplodeForse, explodeCube.transform.position, _explosionRadius);
        }
    }
}