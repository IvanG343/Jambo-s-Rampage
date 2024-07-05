using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn params")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private int maxEnemiesToSpawn;
    private float nextSpawnTime;

    [Header("Detection params")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float offset;
    [SerializeField] private float colliderSize;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        nextSpawnTime = 0;
    }

    private void Update()
    {
        if (IsInView() && CanSpawnEnemyInView())
            SpawnEnemy();
    }

    private bool IsInView()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * offset * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * colliderSize, boxCollider.bounds.size.y),
            0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private bool CanSpawnEnemyInView()
    {
        int enemiesCount = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy_Melee");
        foreach (GameObject enemy in enemies)
        {
            if (enemy.name == "Kamikaze(Clone)")
                enemiesCount++;
        }
        return enemiesCount < maxEnemiesToSpawn;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * offset * transform.localScale.x * colliderDistance,
            new Vector2(boxCollider.bounds.size.x * colliderSize, boxCollider.bounds.size.y));
    }

    private void SpawnEnemy()
    {
        if(Time.time > nextSpawnTime)
        {
            GameObject enemyMelee = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }
}
