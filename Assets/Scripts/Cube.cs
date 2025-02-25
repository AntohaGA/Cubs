using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float Chance { get; private set; }

    private void Awake()
    {
        Chance = 100;
    }

    public void ChangeColor()
    {
        if (TryGetComponent(out Renderer renderer))
        {
            renderer.material.SetColor("_Color", Random.ColorHSV());
        }
    }

    public void Explode()
    {
        if (TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    public bool IsDivide()
    {
        const int MinProcent = 0;
        const int MaxProcent = 99;

        if (Random.Range(MinProcent, MaxProcent) < Chance)
        {
            return true;
        }

        return false;
    }

    public void SetNewChanceDivide(float oldChance)
    {
        Chance = oldChance / 2;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}