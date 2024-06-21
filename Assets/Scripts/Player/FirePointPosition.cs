using UnityEngine;

public class FirePointPosition : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private Vector2 standPos, crouchPos;

    private void Start()
    {
        playerMovement = GetComponentInParent<PlayerMovement>();
        standPos = transform.localPosition;
    }

    private void Update()
    {
        if(playerMovement.isCrouched)
            transform.localPosition = crouchPos;
        else
            transform.localPosition = standPos;
    }
}
