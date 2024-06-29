using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health params")]
    [SerializeField] protected float maxHealth;
    protected float currentHealth;

    [Header("Components")]
    [SerializeField] protected Behaviour[] componentsToDisable;

    [Header("References")]
    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected EnemyHealthBar enemyHealthBar;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        enemyHealthBar = GetComponentInChildren<EnemyHealthBar>();
        if(enemyHealthBar != null)
            UpdateHealthBar(currentHealth, maxHealth);
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth > 0)
            OnDamageTaken();
        else
            OnDeath();
    }

    protected virtual void OnDamageTaken()
    {
        if (enemyHealthBar != null)
            UpdateHealthBar(currentHealth, maxHealth);
    }

    protected virtual void OnDeath()
    {
        foreach (Behaviour component in componentsToDisable)
            component.enabled = false;

        rb.isKinematic = true;
        animator.SetTrigger("Die");
    }

    private void UpdateHealthBar(float _currentHealth, float _maxHealth)
    {
        enemyHealthBar.SetHealth(_currentHealth, _maxHealth);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
