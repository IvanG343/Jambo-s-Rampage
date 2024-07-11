using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health params")]
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    private bool isAlive = true;

    [Header("Components")]
    [SerializeField] protected Behaviour[] componentsToDisable;

    [Header("SFX")]
    [SerializeField] protected AudioClip defeatedSound;

    [Header("References")]
    protected Rigidbody2D rb;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;
    protected EnemyHealthBar enemyHealthBar;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    public float MaxHealth
    {
        get { return maxHealth; }
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
            if (isAlive)
                OnDeath();
    }

    protected virtual void OnDamageTaken()
    {
        if (enemyHealthBar != null)
            UpdateHealthBar(currentHealth, maxHealth);
    }

    protected virtual void OnDeath()
    {
        isAlive = false;

        foreach (Behaviour component in componentsToDisable)
            component.enabled = false;

        animator.SetTrigger("Die");
        gameObject.layer = 14; //Move object to "Dead" layer, so the object is no longer interactible with other objects like player, enemy, bullets etc. 

        SoundManager.instance.PlaySound(defeatedSound);
        GameManager.instance.AddScorePoints(maxHealth * 100);
    }

    private void UpdateHealthBar(float _currentHealth, float _maxHealth)
    {
        enemyHealthBar.SetHealth(_currentHealth, _maxHealth);
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }
}
