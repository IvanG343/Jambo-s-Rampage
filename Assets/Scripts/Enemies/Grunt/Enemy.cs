using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [Header("Detection params")]
    protected Transform playerTransform;

    [Header("Damage params")]
    [SerializeField] protected float explodeDamage;

    [Header("References")]
    protected Animator anim;
    protected float direction;
    private Camera mainCamera;

    protected virtual void Start()
    {
        playerTransform = GameObject.Find("Hero").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    protected virtual void Update()
    {
        if (IsInView())
        {
            SetDirection();
            PerformAction();
        }
    }

    protected bool IsInView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
    }

    protected void SetDirection()
    {
        direction = transform.position.x < playerTransform.position.x ? 1 : -1;
        FlipSprite(direction);
    }

    protected void FlipSprite(float _direction)
    {
        transform.localScale = new Vector2(_direction, 1);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(explodeDamage);
            gameObject.GetComponent<Health>().TakeDamage(1000);
            anim.SetTrigger("Explode");
        }
    }

    protected abstract void PerformAction();
}
