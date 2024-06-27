using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private static CameraShake instance;

    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public static void Shake()
    {
        if (instance != null && instance.impulseSource != null)
        {
            instance.impulseSource.GenerateImpulse();
        }
    }
}
