using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        CameraShake.Shake();
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
