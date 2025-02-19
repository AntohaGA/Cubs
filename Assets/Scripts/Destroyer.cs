using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private InitializatiorCubs _creatorCubs;

    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public int DecrimenterScale  { get ; set; }

    public float ChanñeInitialization { get; set; }

    private void Awake()
    {
        DecrimenterScale = 2;
        ChanñeInitialization = 100;
        _creatorCubs = Camera.main.GetComponent<InitializatiorCubs>();
    }

    private void OnMouseUpAsButton()
    {
        _creatorCubs.AddCubesByChance(DecrimenterScale, ChanñeInitialization);
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach(Rigidbody explodableObject in GetExplodableObjects())
        {
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach(Collider hit in hits)
        {
            if(hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);
        }

        return cubes;
    }
}