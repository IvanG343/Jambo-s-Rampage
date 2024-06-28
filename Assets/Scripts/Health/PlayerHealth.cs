using System.Collections;
using UnityEngine;

public class PlayerHealth : Health
{
    [Header("Invulnerability")]
    [SerializeField] private float invDuration;
    [SerializeField] private int flashes;
    private SpriteRenderer playerSprite;
    public bool isInv { get; private set; }

    [Header("References")]
    private PlayerInput playerInput;
    private BoxCollider2D boxCollider;
    public PhysicsMaterial2D staticMat;

    protected override void Start()
    {
        base.Start();
        playerInput = GetComponent<PlayerInput>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    protected override void OnDamageTaken()
    {
        CameraShake.Shake();
        animator.SetTrigger("Hurt");
        StartCoroutine(Invulnerability());
    }

    protected override void OnDeath()
    {
        CameraShake.Shake();
        playerInput.enabled = false;
        boxCollider.enabled = false;
        rb.isKinematic = true;
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
            playerSprite.color = new Color(1, 1, 1, 0.5f);
            yield return new WaitForSeconds(invDuration / (flashes * 2));
            playerSprite.color = Color.white;
            yield return new WaitForSeconds(invDuration / (flashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
        isInv = false;
    }
}
