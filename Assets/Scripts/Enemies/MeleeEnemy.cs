using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Move params")]
    [SerializeField] private float moveSpeed;
    private Transform enemyTransform;
    private float distance;

    [Header("Damage params")]
    [SerializeField] private float damage;

    protected override void Start()
    {
        base.Start();
        enemyTransform = GetComponent<Transform>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void PerformAction()
    {
        MoveTowardsPlayer();
    }



    private void MoveTowardsPlayer()
    {
        float distanceToPlayer = Mathf.Abs(playerTransform.position.x - transform.position.x);
        Debug.Log(distanceToPlayer);
        if (distanceToPlayer > 0.1f)
        {
            transform.position = new Vector2(enemyTransform.position.x + Time.deltaTime * direction * moveSpeed, enemyTransform.position.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            anim.SetTrigger("Explode");
        }
    }
}
