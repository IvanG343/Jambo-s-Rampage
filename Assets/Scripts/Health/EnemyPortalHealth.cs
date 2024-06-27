using UnityEngine;

public class EnemyPortalHealth : Health
{
    [Header("References")]
    [SerializeField] GameObject explosion;

    protected override void Start()
    {
        base.Start();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
    }
}
