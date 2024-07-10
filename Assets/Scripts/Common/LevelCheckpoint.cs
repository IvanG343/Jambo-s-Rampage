using UnityEngine;

public class LevelCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            GameManager.instance.LevelComplete();
    }
}
