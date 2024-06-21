using UnityEngine;

public class PlayerColliderController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private CapsuleCollider2D playerCollider;

    [SerializeField] private Vector2 standOffset, standSize;
    [SerializeField] private Vector2 crouchOffset, crouchSize;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerCollider = GetComponent<CapsuleCollider2D>();

        standSize = playerCollider.size;
        standOffset = playerCollider.offset;
    }

    private void Update()
    {
        if(playerMovement.isCrouched)
        {
            playerCollider.size = crouchSize;
            playerCollider.offset = crouchOffset;
        }
        else
        {
            playerCollider.size = standSize;
            playerCollider.offset = standOffset;
        }
    }
}
