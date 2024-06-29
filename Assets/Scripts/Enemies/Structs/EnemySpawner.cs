using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn params")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private int maxEnemiesToSpawn;
    private float nextSpawnTime;

    [Header("References")]
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        nextSpawnTime = 0;
    }

    private void Update()
    {
        if (IsInView() && CanSpawnEnemyInView())
            SpawnEnemy();
    }

    private bool IsInView()
    {
        Vector3 screenPoint = mainCamera.WorldToViewportPoint(transform.position);
        return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
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

    private void SpawnEnemy()
    {
        if(Time.time > nextSpawnTime)
        {
            GameObject enemyMelee = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }
}
