using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Move params")]
    [SerializeField] private float moveSpeed;
    private Transform enemyTransform;

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
        if (distanceToPlayer > 0.5f)
        {
            transform.position = new Vector2(enemyTransform.position.x + Time.deltaTime * direction * moveSpeed, enemyTransform.position.y);
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
