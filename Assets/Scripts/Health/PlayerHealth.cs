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
        StartCoroutine(Invulnerability(invDuration, flashes));
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        CameraShake.Shake();
        rb.sharedMaterial = staticMat;
    }

    public void GameOverScreen()
    {
        GameManager.instance.LevelFailed();
    }

    public void Heal(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, maxHealth);
    }

    private IEnumerator Invulnerability(float _invDuration, int _flashes)
    {
        Physics2D.IgnoreLayerCollision(7, 13, true);
        isInv = true;
        for (int i = 0; i < flashes; i++)
        {
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(_invDuration / (_flashes * 2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(_invDuration / (_flashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 13, false);
        isInv = false;
    }
}
