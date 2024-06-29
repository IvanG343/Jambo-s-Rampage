using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Health>().TakeDamage(damage);
        DestroyObject();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
