using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health params")]
    [SerializeField] protected float maxHealth;
    protected float currentHealth;

    [Header("Components")]
    [SerializeField] private Behaviour[] components;
    protected Rigidbody2D rb;
    protected Animator animator;

    public float CurrentHealth
    {
        get { return currentHealth; }
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            OnDamageTaken();
        }
        else
        {
            animator.SetTrigger("Die");
            OnDeath();
        }
    }

    protected virtual void OnDamageTaken()
    {
        
    }

    protected virtual void OnDeath()
    {
        foreach (Behaviour component in components)
            component.enabled = false;

        if(gameObject.layer == 8)
            rb.isKinematic = true;
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
