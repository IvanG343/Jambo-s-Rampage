using System.Collections;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Fire Params")]
    [SerializeField] private float fireForce;
    [SerializeField] private float attackCooldown;
    [SerializeField] private int bulletsPerShot;
    [SerializeField] private float burstInterval = 0.1f;
    private float cooldownTimer;

    [Header("SFX")]
    [SerializeField] private AudioClip shotSound;

    [Header("References")]
    [SerializeField] private GameObject enemyBullet;
    [SerializeField] private Transform firePoint;

    protected override void Start()
    {
        base.Start();
        cooldownTimer = 0;
    }

    protected override void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer >= attackCooldown)
            base.Update();
    }

    protected override void PerformAction()
    {
        StartCoroutine(ShootBurst(direction));
    }

    private IEnumerator ShootBurst(float _direction)
    {
        cooldownTimer = 0;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            ShootSingleBullet(_direction);
            yield return new WaitForSeconds(burstInterval);
        }
    }

    private void ShootSingleBullet(float _direction)
    {
        GameObject newBullet = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D newBulletVelocity = newBullet.GetComponent<Rigidbody2D>();
        newBulletVelocity.velocity = new Vector2(fireForce * _direction, newBulletVelocity.velocity.y);

        anim.SetTrigger("Shoot");
        SoundManager.instance.PlaySound(shotSound);
    }
}
