using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Health playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Hero").GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth.Heal(1);
            Destroy(gameObject);
        }

        
    }
}
