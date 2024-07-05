using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health targetHealth = collision.GetComponent<Health>();

        if (targetHealth != null && targetHealth.CurrentHealth != 0)
            targetHealth.TakeDamage(damage);

        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
