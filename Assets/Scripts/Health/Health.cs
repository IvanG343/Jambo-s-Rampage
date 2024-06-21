using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health params")]
    [SerializeField] private float maxHealth;
    public float currentHealth { get; private set; }
    public bool isAlive = true;

    [Header("Invulnerability")]
    [SerializeField] private float invDuration;
    [SerializeField] private int flashes;
    private SpriteRenderer playerSprite;
    public bool isInv { get; private set; }

    [Header("Components")]
    private Animator animator;
    private PlayerInput playerInput;

    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if(currentHealth > 0)
        {
            animator.SetTrigger("Hurt");
            StartCoroutine(Invulnerability());
        }
        else
        {
            if(isAlive)
            {
                isAlive = false;
                animator.SetTrigger("Die");
                playerInput.enabled = false;
            }
        }

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
