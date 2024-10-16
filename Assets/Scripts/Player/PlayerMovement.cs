using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement params")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] LayerMask groundLayer;

    [Header("Player state params")]
    public bool isCrouched = false;
    private bool canMove = true;

    [Header("References")]
    private Rigidbody2D playerRbody;
    private Animator playerAnim;
    private BoxCollider2D playerCollider;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;

    private void Start()
    {
        playerRbody = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        playerCollider = GetComponent<BoxCollider2D>();
    }

    public void Move(float dirHor, float dirVert, bool jumpBtnPressed)
    {
        FlipSprite(dirHor);
        playerAnim.SetBool("isGrounded", isGrounded());

        if (canMove)
        {
            MovePlayer(dirHor);
            playerAnim.SetBool("isRunning", dirHor != 0);
        }

        if(jumpBtnPressed && isGrounded() && !isCrouched)
        {
            Jump();
        }

        if (isGrounded())
        {
            Crouch(dirVert);
            playerAnim.SetBool("isCrouched", isCrouched);
        }

        if (dirVert == -1 && jumpBtnPressed && isGrounded() && IsOnBridge())
            StartCoroutine(FallThroughPlatform());
    }

    private void MovePlayer(float dirHor)
    {
        playerRbody.velocity = new Vector2(dirHor * speed, playerRbody.velocity.y);
    }

    private void Jump()
    {
        playerRbody.velocity = new Vector2(playerRbody.velocity.x, jumpForce);
        SoundManager.instance.PlaySound(jumpSound);
    }

    private void Crouch(float dirVert)
    {
        if(dirVert == -1)
        {
            isCrouched = true;
            canMove = false;
            playerRbody.velocity = Vector2.zero;
        }
        else
        {
            isCrouched = false;
            canMove = true;
        }
    }

    private void FlipSprite(float direction)
    {
        if (direction > 0)
            transform.localScale = new Vector2(1, 1);
        else if (direction < 0)
            transform.localScale = new Vector2(-1, 1);
    }

    private IEnumerator FallThroughPlatform()
    {
        playerCollider.enabled = false;
        yield return new WaitForSeconds(0.2f);
        playerCollider.enabled = true;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool IsOnBridge()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        if (raycastHit.collider != null && raycastHit.collider.CompareTag("Bridge"))
        {
            return true;
        }
        return false;
    }
}
