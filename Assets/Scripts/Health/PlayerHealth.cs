using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [Header("Invulnerability")]
    [SerializeField] private float invDuration;
    [SerializeField] private int flashes;
    public bool isInv { get; private set; }

    [Header("References")]
    public PhysicsMaterial2D staticMat;

    protected override void OnDamageTaken()
    {
        CameraShake.Shake();
        animator.SetTrigger("Hurt");
        StartCoroutine(Invulnerability());
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        CameraShake.Shake();
        rb.velocity = Vector3.zero;
        rb.sharedMaterial = staticMat;
    }

    public void Heal(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }

    private IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        isInv = true;
        for (int i = 0; i < flashes; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(invDuration / (flashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(invDuration / (flashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        isInv = false;
    }
}
